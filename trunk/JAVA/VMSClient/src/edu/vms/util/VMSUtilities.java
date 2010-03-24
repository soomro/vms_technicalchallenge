package edu.vms.util;

/**
 * This class will provide methodes for basik checkings
 * @author Tigran Harutyunyan
 */
public class VMSUtilities {
    public VMSUtilities(){

    }
    /**
     * This method validate's the username and password
     * @param username - the username of the user
     * @param password - the password of the user
     * @return
     */
    public static boolean checkUsernameAndPassword(String username, String password){
        System.out.println("username : " + username);
        System.out.println("password : " + password);
        if(!username.equals("admin") || !password.equals("admin")){
            System.out.println("false");
            return false;
        }
        System.out.println("true");
        return true;
    }

}
