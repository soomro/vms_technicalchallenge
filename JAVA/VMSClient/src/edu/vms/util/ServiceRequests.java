/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms.util;

import edu.vms.ClientMIDlet;
import java.lang.String;
import javax.microedition.lcdui.TextField;
import javax.microedition.midlet.MIDlet;
import org.netbeans.microedition.lcdui.WaitScreen;
import service.Service_Stub;
import ws.WS_Stub;

/**
 *
 * @author tiko
 */
public class ServiceRequests extends Thread {

    private String answer = "";
    private ClientMIDlet main;
    public String operation = new String();
    public static final String LOGIN = "LOGIN";
    public static final String CHECKUPDATE = "CHECKUPDATE";
    public static final String GETREQUEST = "GETREQUEST";
    public static final String ACCEPTREQUEST = "ACCEPTREQUEST";
    public static final String REJECTREQUEST = "REJECTREQUEST";
    private String username;
    private String password;

    public ServiceRequests(MIDlet m) {
        main = (ClientMIDlet) m;
        username = main.getLogin().getUsername();
        password = main.getLogin().getPassword();
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
    }

    private void login() {
        System.out.println("method : login()");
        WS_Stub service = new WS_Stub();
        try {
            answer = service.login(username, password);
            if (!answer.equals("")) {
                main.guid = answer;
                System.out.println("GUID = " + answer);
                main.loggedIn = true;
                System.out.println("answer = " + answer);
                main.commandAction(ClientMIDlet.SUCCESS_LOGIN, main.getWaitScreen());
            } else {
                main.commandAction(WaitScreen.FAILURE_COMMAND, main.getWaitScreen());
            }
        } catch (Exception ex) {
            ex.printStackTrace();
            main.commandAction(WaitScreen.FAILURE_COMMAND, main.getWaitScreen());

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
            main.requestID = Integer.parseInt(TextParser.getRequestID(answer));
            System.out.println("request = " + request + " " + main.requestID);
            main.getChoiceGroup().set(0, request, null);
            System.out.println("aaaaaaaaaaaaaaa");
            main.getChoiceGroup1().insert(0, answer, null);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void getRequest() {
        System.out.println("method : getRequest()");
        WS_Stub service = new WS_Stub();
        try {
            answer = service.getRequest(main.requestID, main.getLogin().getUsername());
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
    private void drawRequest(String rLocation, String rName, String rMessage, String[] iName, int[] iNumber){
        main.getRequest().append(rLocation);
        main.getRequest().append("\n");
        main.getRequest().append(rMessage);
        main.getRequest().append("\n");
        main.getRequest().append("Need list");
        main.getRequest().append("\n");
        for(int i = 0; i < iName.length; i++){
            TextField tField = new TextField(iName[i] + "/ " + iNumber[i], "0", 3, 3);
            main.getRequest().append(tField);
            main.getRequest().append("\n");
            TextField tField1 = new TextField(iName[i] + "/ " + iNumber[i], "0", 3, 3);
            main.getRequest().append(tField1);
            main.getRequest().append("\n");
        }
    }
}
