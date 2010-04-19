package edu.vms.util;

import edu.vms.ClientMIDlet;
import java.util.Vector;
import javax.microedition.lcdui.TextField;
import javax.microedition.location.*;

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
    public void checkUsernameAndPassword(String username, String password) {
        try {
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.LOGIN;
            service.start();
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
    public void calculateAmount() {
        midlet.collectedAmount = new Vector();
        for (int i = 0; i < midlet.getRequest().size(); i++) {
            if (midlet.getRequest().get(i) instanceof TextField) {
                TextField tf = (TextField) midlet.getRequest().get(i);
                midlet.collectedAmount.addElement(tf.getString());
            }
            i++;
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
        midlet.requestID = 0;
        midlet.accepted = false;
        midlet.getChoiceGroup().set(0, "", null);
        midlet.getChoiceGroup().setSelectedIndex(0, false);
        answerRequest();
    }

    /*
     * drawRequest draws the page of request
     */
    public void drawViewRequest(String rLocation, String rName, String rMessage, String[] iName, int[] iNumber) {
        midlet.getViewRequest().deleteAll();
        midlet.getViewRequest().append(rLocation);
        midlet.getViewRequest().append("\n");
        midlet.getViewRequest().append(rMessage);
        midlet.getViewRequest().append("\n");
        midlet.getViewRequest().append("Need list");
        midlet.getViewRequest().append("\n");
        for (int i = 0; i < iName.length; i++) {
            midlet.getViewRequest().append(iName[i] + "/ " + iNumber[i] + "/ " + (String) midlet.collectedAmount.elementAt(i));
            midlet.getViewRequest().append("\n");            
            midlet.getViewRequest().append(iName[i] + "/ " + iNumber[i] + "/ " + (String) midlet.collectedAmount.elementAt(i));
            midlet.getViewRequest().append("\n");
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
}
