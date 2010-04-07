package edu.vms.web;
import javax.xml.namespace.QName;

public interface WS extends java.rmi.Remote {

    /**
     *
     */
    public String login(String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public String getRequest(int requestID, String userID) throws java.rmi.RemoteException;

    /**
     *
     */
    public String checkUpdate(String usename, String guid) throws java.rmi.RemoteException;

    /**
     *
     */
    public String helloWorld() throws java.rmi.RemoteException;

}
