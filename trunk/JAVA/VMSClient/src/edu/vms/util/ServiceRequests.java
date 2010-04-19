/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms.util;

import edu.vms.ClientMIDlet;
import edu.vms.web.WS_Stub;
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
    private String username;
    private String password;

    public ServiceRequests(MIDlet m) {
        midlet = (ClientMIDlet) m;
        username = midlet.getLogin().getUsername();
        password = midlet.getLogin().getPassword();
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

    }

    private void login() {
        System.out.println("method : login()");
        WS_Stub service = new WS_Stub();
        try {
            answer = service.login(username, password);
            if (!answer.equals("")) {
                midlet.guid = answer;
                System.out.println("GUID = " + answer);
                midlet.loggedIn = true;
                System.out.println("answer = " + answer);
                midlet.commandAction(ClientMIDlet.SUCCESS_LOGIN, midlet.getWaitScreen());
            } else {
                midlet.commandAction(WaitScreen.FAILURE_COMMAND, midlet.getWaitScreen());
            }
        } catch (Exception ex) {
            ex.printStackTrace();
            midlet.commandAction(WaitScreen.FAILURE_COMMAND, midlet.getWaitScreen());

        }
    }

    private void checkUpdate() {
        System.out.println("method : checkUpdate()");
        WS_Stub service = new WS_Stub();
        String request = new String();
        try {
            answer = service.checkUpdate(username, password);
            System.out.println("answer = " + answer);
            request = TextParser.getRequest(answer);
            midlet.requestID = Integer.parseInt(TextParser.getRequestID(answer));
            System.out.println("request = " + request + " " + midlet.requestID);
            midlet.getChoiceGroup().set(0, request, null);
            System.out.println("aaaaaaaaaaaaaaa");
            //midlet.getChoiceGroup1().insert(0, answer, null);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void getRequest() {
        System.out.println("method : getRequest()");
        WS_Stub service = new WS_Stub();
        try {
            answer = service.getRequest(midlet.requestID, midlet.getLogin().getUsername());
            System.out.println("answer = " + answer);
            String[] iName = {"Car/ Item"};
            int[] iNumber = {5};
            String location = "Angered Centre";
            String message = "Hello, we need your help";
            String name = "Angered disaster";
            drawRequest(location, name, message, iName, iNumber);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void acceptRequest() {
        System.out.println("method : acceptRequest()");
        WS_Stub service = new WS_Stub();
        try {
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void rejectRequest() {
        System.out.println("method : rejectRequest()");
        WS_Stub service = new WS_Stub();
        try {
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    /*
     * drawRequest draws the page of request
     */
    private void drawRequest(String rLocation, String rName, String rMessage, String[] iName, int[] iNumber) {
        midlet.getRequest().deleteAll();
        midlet.getRequest().append(rLocation);
        midlet.getRequest().append("\n");
        midlet.getRequest().append(rMessage);
        midlet.getRequest().append("\n");
        midlet.getRequest().append("Need list");
        midlet.getRequest().append("\n");
        for (int i = 0; i < iName.length; i++) {
            TextField tField = new TextField(iName[i] + "/ " + iNumber[i], "0", 3, 3);
            tField.setConstraints(TextField.NUMERIC);
            midlet.getRequest().append(tField);
            midlet.getRequest().append("\n");
            TextField tField1 = new TextField(iName[i] + "/ " + iNumber[i], "0", 3, 3);
            tField1.setConstraints(TextField.NUMERIC);
            midlet.getRequest().append(tField1);
            midlet.getRequest().append("\n");
        }
    }

    private void checkPeriodically() {
        System.out.println("main.loggedIn" + midlet.loggedIn);
        while (midlet.loggedIn) {
            try {
                synchronized (this) {
                    checkUpdate();
                    wait(300000);
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
        midlet.location = "000000#111111";
    }

    private void reportIncidentProgress() {
        try{

        TextField prsFld = (TextField) midlet.getReportProgress().get(0);
        TextField msgFld = (TextField) midlet.getReportProgress().get(1);

        String persentage = prsFld.getString();
        String message = msgFld.getString();

        if(Integer.parseInt(persentage) > 100){
            persentage = "100";
        }

        prsFld.setString("");
        msgFld.setString("");
        System.out.println(persentage + " " + message);
        //TODO: send the data to the server after the service is implemented
        midlet.switchDisplayable(null, midlet.getMain());
        }
        catch(Exception e){
            e.printStackTrace();
        }
    }

    private void reportIncident() {
        try{
        TextField locFld = (TextField) midlet.getReportIncident().get(0);
        TextField typeFld = (TextField) midlet.getReportIncident().get(1);
        TextField msgFld = (TextField) midlet.getReportIncident().get(2);

        String location = locFld.getString();
        String type = typeFld.getString();
        String message = typeFld.getString();

        locFld.setString("");
        typeFld.setString("");
        msgFld.setString("");
        System.out.println(location + " " + type + " " + message);
        //TODO: send the data to the server after the service is implemented
        midlet.switchDisplayable(null, midlet.getMain());
        }
        catch(Exception e){
            e.printStackTrace();
        }
    }
}
