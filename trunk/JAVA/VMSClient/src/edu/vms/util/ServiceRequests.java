/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms.util;

import edu.vms.ClientMIDlet;
import edu.vms.web.GetAlertResponse;
import edu.vms.web.GetRequestResponse;
import edu.vms.web.RespondToRequestResponse;
import edu.vms.web.WS_Stub;
import java.io.IOException;
import java.io.InputStream;
import javax.microedition.io.Connector;
import javax.microedition.io.HttpConnection;
import javax.microedition.lcdui.ChoiceGroup;
import javax.microedition.lcdui.TextField;
import javax.microedition.midlet.MIDlet;
import org.netbeans.microedition.lcdui.WaitScreen;

/**
 *
 * @author tiko
 */
public class ServiceRequests extends Thread {

    private String answer = "";
    private ClientMIDlet midlet;
    public String operation = new String();
    public static final String LOGIN = "LOGIN";
    public static final String CHECKUPDATE = "CHECKUPDATE";
    public static final String GETREQUEST = "GETREQUEST";
    public static final String ACCEPTREQUEST = "ACCEPTREQUEST";
    public static final String REJECTREQUEST = "REJECTREQUEST";
    public static final String CHECKPERIODICALLY = "CHECKPERIODICALLY";
    public static final String GETCOORDINATES = "GETCOORDINATES";
    public static final String REPORTINCIDENT = "REPORTINCIDENT";
    public static final String REPORTPROGRESS = "REPORTPROGRESS";
    public static final String GETALERT = "GETALERT";
    private String username;
    private String password;

    public ServiceRequests(MIDlet m) {
        midlet = (ClientMIDlet) m;
        username = midlet.getUsername();
        password = midlet.getPassword();
    }

    public void run() {
        if (operation.equals(LOGIN)) {
            login();
            return;
        }
        if (operation.equals(CHECKUPDATE)) {
            checkUpdate();
            return;
        }
        if (operation.equals(GETREQUEST)) {
            getRequest();
            return;
        }
        if (operation.equals(ACCEPTREQUEST)) {
            acceptRequest();
            return;
        }
        if (operation.equals(REJECTREQUEST)) {
            rejectRequest();
            return;
        }
        if (operation.equals(CHECKPERIODICALLY)) {
            checkPeriodically();
            return;
        }
        if (operation.equals(GETCOORDINATES)) {
            getCoordinates();
            return;
        }
        if (operation.equals(REPORTINCIDENT)) {
            reportIncident();
            return;
        }
        if (operation.equals(REPORTPROGRESS)) {
            reportIncidentProgress();
            return;
        }
        if (operation.equals(GETALERT)) {
            getAlert();
            return;
        }

    }

    private void login() {
        WS_Stub service = new WS_Stub();
        try {

            midlet.loggedIn = service.login(username, password);
            if (midlet.loggedIn) {
                midlet.getLogin().getTicker().setString("");
                midlet.commandAction(ClientMIDlet.SUCCESS_LOGIN, midlet.getWaitScreen());
            } else {
                midlet.getLogin().getTicker().setString("Incorrect username and/or password");
                midlet.commandAction(WaitScreen.FAILURE_COMMAND, midlet.getWaitScreen());
            }
        } catch (Exception ex) {
            ex.printStackTrace();
            midlet.getLogin().getTicker().setString("Server error");
            midlet.commandAction(WaitScreen.FAILURE_COMMAND, midlet.getWaitScreen());

        }
    }

    private void checkUpdate() {
        WS_Stub service = new WS_Stub();
        String request = new String();
        try {
            getCoordinates();
            answer = service.checkUpdate(username, password, midlet.lat, midlet.lon);
            TextParser.pasrUpdates(answer, midlet);
            midlet.getChoiceGroup().set(0, midlet.reqInfo.name, null);
            for (int i = 0; i < 5; i++) {
                midlet.getChoiceGroup2().set(i, midlet.alertN[i], null);
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void getRequest() {
        WS_Stub service = new WS_Stub();
        try {
            GetRequestResponse reqRespons = service.getRequest(midlet.reqInfo.ID, username, password);
            TextParser.getRequestInfo(reqRespons.getGetRequestResult(), midlet);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        if (midlet.accepted) {
            midlet.switchDisplayable(null, midlet.getViewRequest());
            midlet.util.drawViewRequest(midlet.reqInfo);
        } else {
            if (!"".equals(midlet.reqInfo.ID.trim())) {
                midlet.switchDisplayable(null, midlet.getRequest());
                midlet.util.drawRequest();
            }
        }
    }

    private void acceptRequest() {
        WS_Stub service = new WS_Stub();
        try {

            String responce = TextParser.createResponce(midlet);
            RespondToRequestResponse rr = service.respondToRequest(midlet.reqInfo.ID, username, password, responce);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void rejectRequest() {
        WS_Stub service = new WS_Stub();
        try {
            String responce = TextParser.createResponceForReject(midlet);
            service.respondToRequest(midlet.reqInfo.ID, username, password, responce);
            midlet.reqInfo = new Request();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    /*
     * drawRequest draws the page of request
     */
    private void checkPeriodically() {
        while (midlet.loggedIn) {
            try {
                synchronized (this) {
                    checkUpdate();
                    wait(60000);
                }
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }

    /**
     * This method get the currecnt coordinates of the volunteers and update the location information
     */
    private void getCoordinates() {
        try {
            HttpConnection httpCon = (HttpConnection) Connector.open("http://www.ipaddressgeolocation.com");
            InputStream is = httpCon.openDataInputStream();
            StringBuffer content = new StringBuffer();
            int next = is.read();
            while (next != -1) {
                next = is.read();
                content.append((char) next);
            }
            httpCon.close();
            String lt = getLat(content);
            String ln = getLon(content);

            midlet.lat = Float.parseFloat(lt);
            midlet.lon = Float.parseFloat(ln);
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    private void reportIncidentProgress() {
        try {
            WS_Stub service = new WS_Stub();
            TextField msgFld = (TextField) midlet.getReportProgress().get(0);

            int progress = ((ChoiceGroup) midlet.getReportProgress().get(1)).getSelectedIndex();
            String message = msgFld.getString();

            msgFld.setString("");
            service.progressReport(midlet.reqInfo.ID, message, progress, username, password);
            midlet.switchDisplayable(null, midlet.getMain());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void reportIncident() {
        try {
            WS_Stub service = new WS_Stub();
            TextField locFld = (TextField) midlet.getReportIncident().get(0);
            TextField msgFld = (TextField) midlet.getReportIncident().get(1);

            int type = ((ChoiceGroup) midlet.getReportIncident().get(2)).getSelectedIndex();
            String location = locFld.getString();
            String message = msgFld.getString();

            locFld.setString("");
            msgFld.setString("");
            service.incidentReport(message, location, type, username, password);
            midlet.switchDisplayable(null, midlet.getMain());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private String getLat(StringBuffer content) {
        String c = content.toString();
        int i = c.indexOf("My IP address latitude");
        c = c.substring(i + 41, c.length());
        int e = c.indexOf("&deg");
        return c.substring(0, e);
    }

    private String getLon(StringBuffer content) {
        String c = content.toString();
        int i = c.indexOf("My IP address longitude");
        c = c.substring(i + 42, c.length());
        int e = c.indexOf("&deg");
        return c.substring(0, e);
    }

    private void getAlert() {
        WS_Stub service = new WS_Stub();
        try {
            GetAlertResponse alert = service.getAlert(midlet.alertIDs[midlet.alertIndex], username, password);
            midlet.getAlert().deleteAll();
            midlet.getAlert().append(alert.getGetAlertResult());
            midlet.switchDisplayable(null, midlet.getAlert());

        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
