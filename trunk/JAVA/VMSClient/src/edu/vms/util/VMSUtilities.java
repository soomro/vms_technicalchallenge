package edu.vms.util;

import edu.vms.ClientMIDlet;
import javax.microedition.lcdui.TextField;

/**
 * This class will provide methodes for basic checkings
 * @author Tigran Harutyunyan
 */
public class VMSUtilities {

    ClientMIDlet midlet;

    public VMSUtilities(ClientMIDlet m) {
        midlet = m;

    }

    /**
     * This method validate's the username and password
     * @param username - the username of the user
     * @param password - the password of the user
     * @return
     */
    public void checkUsernameAndPassword() {
        try {
            if (midlet.getUsername().equals("") || midlet.getPassword().equals("")) {
                midlet.getLogin().getTicker().setString("username and/or password cannot be empty");
            } else {
                ServiceRequests service = new ServiceRequests(midlet);
                service.operation = ServiceRequests.LOGIN;
                service.start();
            }
        } catch (Exception re) {
            re.printStackTrace();
        }
    }

    /*
     * checkRequest method runs a thread which connects to the server, check for the updated and refresh
     * refresh information in mobile app     
     */
    public void checkUpdate() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.CHECKUPDATE;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }
    /*
     * getRequestInfo method runs a thread, which connects to the server and gets the request information
     * for the request by the given request ID
     */

    public void getRequestInfo() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.GETREQUEST;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }
    /*
     * answerRequest method runs a thread, which sends to the server the request answer with need list
     */

    public void answerRequest() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            if (midlet.accepted) {
                service.operation = ServiceRequests.ACCEPTREQUEST;
            } else {
                service.operation = ServiceRequests.REJECTREQUEST;
            }
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }
    /*
     * checkRequest method runs a thread which connects to the server, check for the updated and refresh
     * refresh information in mobile app
     */

    public void checkPeriodically() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.CHECKPERIODICALLY;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }

    //-------------------------------------------------------
    /*
     *
     */
    public void calculateAmount() {
        int findex = 0;
        for (int i = 0; i < midlet.getRequest().size(); i++) {
            if (midlet.getRequest().get(i) instanceof TextField) {
                TextField tf = (TextField) midlet.getRequest().get(i);
                int c = 0;
                if (!tf.getString().equals("")) {
                    c = Integer.parseInt(tf.getString());
                }
                if (c > Integer.parseInt((String) midlet.reqInfo.nAmount.elementAt(findex))) {
                    c = Integer.parseInt((String) midlet.reqInfo.nAmount.elementAt(findex));
                }
                midlet.reqInfo.nCollected.addElement(Integer.toString(c));
                findex++;
            }
        }
    }

    public void acceptRequest() {
        midlet.accepted = true;
        calculateAmount();
        answerRequest();
    }

    public void logout() {
        midlet.loggedIn = false;
    }

    public void getCoordinates() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.GETCOORDINATES;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }

    }

    public void removeRequest() {
        midlet.reqInfo = new Request();
        midlet.accepted = false;
        midlet.getChoiceGroup().set(0, "", null);
        midlet.getChoiceGroup().setSelectedIndex(0, false);
        answerRequest();
    }

    /*
     * drawRequest draws the page of request
     */
    /*
     *
     * @param username - the username of the user
     * @param password - the password of the user
     */
    public void drawViewRequest(Request request) {
        midlet.getViewRequest().deleteAll();
        midlet.getViewRequest().append(request.name);
        midlet.getViewRequest().append("\n");
        midlet.getViewRequest().append(request.location);
        midlet.getViewRequest().append("\n");
        midlet.getViewRequest().append(request.message);
        midlet.getViewRequest().append("\n");
        midlet.getViewRequest().append("Need list");
        midlet.getViewRequest().append("\n");
        for (int i = 0; i < request.nType.size(); i++) {
            midlet.getViewRequest().append(request.nType.elementAt(i) + "/ " + request.nUnit.elementAt(i) + "/ " + request.nAmount.elementAt(i) + "/ " + (String) midlet.reqInfo.nCollected.elementAt(i));
            midlet.getViewRequest().append("\n");
        }

    }

    public void drawRequest() {
        Request request = midlet.reqInfo;
        midlet.getRequest().deleteAll();
        midlet.getViewRequest().append(request.name);
        midlet.getViewRequest().append("\n");
        midlet.getRequest().append(request.location);
        midlet.getRequest().append("\n");
        midlet.getRequest().append(request.message);
        midlet.getRequest().append("\n");
        midlet.getRequest().append("Need list");
        midlet.getRequest().append("\n");
        for (int i = 0; i < request.nAmount.size(); i++) {
            TextField tField = new TextField((String) request.nType.elementAt(i) + "/ " + request.nUnit.elementAt(i)
                    + "/ " + request.nAmount.elementAt(i), "", 3, 3);
            tField.setConstraints(TextField.NUMERIC);
            midlet.getRequest().append(tField);
            midlet.getRequest().append("\n");
        }
    }

    public void sendReport() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.REPORTINCIDENT;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }

    public void sendProgress() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.REPORTPROGRESS;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }

    public void getAlert() {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.GETALERT;
            service.start();
        } catch (Exception re) {
            re.printStackTrace();
        }
    }

    public boolean checkInRepor() {
        TextField locFld = (TextField) midlet.getReportIncident().get(0);
        TextField msgFld = (TextField) midlet.getReportIncident().get(1);

        String location = locFld.getString();
        String message = msgFld.getString();
        if (location.trim().equals("")) {
            midlet.getReportIncident().getTicker().setString("Location is mandatory");
            return false;
        }
        if (message.trim().equals("")) {
            midlet.getReportIncident().getTicker().setString("Message is mandatory");
            return false;
        }
        return true;

    }
    public boolean checkPrRepor() {
        TextField msgFld = (TextField) midlet.getReportProgress().get(0);

        String message = msgFld.getString();
        if (message.trim().equals("")) {
            midlet.getReportProgress().getTicker().setString("Message is mandatory");
            return false;
        }
        return true;

    }
}
