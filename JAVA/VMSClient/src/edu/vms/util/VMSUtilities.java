package edu.vms.util;

import edu.vms.ClientMIDlet;

/**
 * This class will provide methodes for basik checkings
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
    public boolean checkUsernameAndPassword(String username, String password){
        System.out.println("username : " + username);
        System.out.println("password : " + password);

        try{
            System.out.println("---------------------------------");
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.LOGIN;
            service.start();
            
            System.out.println("---------------------------------");
        }
        catch(Exception re){
            re.printStackTrace();
        } 
        
        if(!username.equals("admin") || !password.equals("admin")){
            System.out.println("false");
            return false;
        }
        System.out.println("true");
        return true;
    }

    public void checkRequests(){
        try{

            System.out.println("---------------------------------");
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.CHECKREQUEST;
            service.start();

            System.out.println("---------------------------------");
        }
        catch(Exception re){
            re.printStackTrace();
        }
    }

    public void getRequestInfo() {
        try{

            System.out.println("+++++++++++++++++++++++++++");
            ServiceRequests service = new ServiceRequests(midlet);
            service.operation = ServiceRequests.GETREQUEST;
            service.start();

            System.out.println("+++++++++++++++++++++++++++++++++");
        }
        catch(Exception re){
            re.printStackTrace();
        }

    }
}
