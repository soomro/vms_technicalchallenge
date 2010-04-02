/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms.util;

import edu.vms.ClientMIDlet;
import javax.bluetooth.UUID;
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
    public static final String LOGIN = "login";
    public static final String CHECKREQUEST = "checkrequest";
    public static final String GETREQUEST = "getrequest";
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
        if (operation.equals(CHECKREQUEST)) {
            checkRequest();
            return;
        }
        if (operation.equals(GETREQUEST)) {
            getRequest(22);
            return;
        }


    }

    private void login() {
        WS_Stub service = new WS_Stub();
        try {
            answer = service.login(username, password);
            if (!answer.equals("")) {
                main.guid = answer;
                System.out.println("GUID = " + answer);
                main.loggedIn = true;
                System.out.println("answer = " + answer);
                main.commandAction(WaitScreen.SUCCESS_COMMAND, main.getWaitScreen());
            } else {
                main.commandAction(WaitScreen.FAILURE_COMMAND, main.getWaitScreen());
            }
        } catch (Exception ex) {
            ex.printStackTrace();
            main.commandAction(WaitScreen.FAILURE_COMMAND, main.getWaitScreen());

        }
    }

    private void checkRequest() {
        WS_Stub service = new WS_Stub();
        String request = new String();
        try {
            answer = service.checkUpdate(username, password);
            System.out.println("answer = " + answer);
            request = TextParser.getRequest(answer);
            main.requestID = TextParser.getRequestID(answer);
            System.out.println("request = " + request + " " + main.requestID);
            main.getChoiceGroup().set(0, request, null);
            System.out.println("aaaaaaaaaaaaaaa");
            main.getChoiceGroup1().insert(0, answer, null);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private void getRequest(int requestID) {
        WS_Stub service = new WS_Stub();
        try {
            answer = service.getRequest(requestID, main.getLogin().getUsername());
            System.out.println("answer = " + answer);
            main.getChoiceGroup().set(0, answer, null);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
