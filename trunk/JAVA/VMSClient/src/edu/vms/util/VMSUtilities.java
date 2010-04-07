package edu.vms.util;

import edu.vms.ClientMIDlet;
import java.util.Vector;
import javax.microedition.lcdui.TextField;

/**
 * This class will provide methodes for basic checkings
 * @author Tigran Harutyunyan
 */
public class VMSUtilities {
    ClientMIDlet midlet;
    public VMSUtilities(ClientMIDlet m){
        midlet = m;

    }
    /**
     * This method validate's the username and password
     * @param username - the username of the user
     * @param password - the password of the user
     * @return
     */
    public void checkUsernameAndPassword(String username, String password){
        try{
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.LOGIN;
            service.start();
        }
        catch(Exception re){
            re.printStackTrace();
        } 
    }

    /*
     * checkRequest method runs a thread which connects to the server, check for the updated and refresh
     * refresh information in mobile app     
     */
    public void checkUpdate(){
        try{
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.CHECKUPDATE;
            service.start();
        }
        catch(Exception re){
            re.printStackTrace();
        }
    }
    /*
     * getRequestInfo method runs a thread, which connects to the server and gets the request information
     * for the request by the given request ID
     */
    public void getRequestInfo() {
        try{
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.GETREQUEST;
            service.start();
        }
        catch(Exception re){
            re.printStackTrace();
        }
    }
    /*
     * answerRequest method runs a thread, which sends to the server the request answer with need list
     */
    public void answerRequest() {
        try{
            ServiceRequests service = new ServiceRequests(midlet);
            if(midlet.accepted){
                service.operation = ServiceRequests.ACCEPTREQUEST;
            } else {
                service.operation = ServiceRequests.REJECTREQUEST;
            }
            service.start();
        }
        catch(Exception re){
            re.printStackTrace();
        }
    }
/*
     * checkRequest method runs a thread which connects to the server, check for the updated and refresh
     * refresh information in mobile app
     */
    public void checkPeriodically(){
        try{
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.CHECKPERIODICALLY;
            service.start();
        }
        catch(Exception re){
            re.printStackTrace();
        }
    }

    //-------------------------------------------------------
    public void calculateAmount(){
        midlet.collectedAmount = new Vector();        
        for(int i = 0; i < midlet.getRequest().size(); i++){
            if(midlet.getRequest().get(i) instanceof TextField){
                TextField tf = (TextField) midlet.getRequest().get(i);
                midlet.collectedAmount.addElement(Integer.valueOf(tf.getString()));
            }
            i++;
        }
    }

    public void logout(){
        midlet.loggedIn = false;

    }
}
