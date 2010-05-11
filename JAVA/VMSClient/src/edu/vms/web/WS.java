package edu.vms.web;
import javax.xml.namespace.QName;

public interface WS extends java.rmi.Remote {

    /**
     * Validates the username and password and returns true if it is correct.
     */
    public boolean login(String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public GetAlertResponse getAlert(String alertID, String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public RespondToRequestResponse respondToRequest(String requestresponseID, String username, String password, String amountProvided) throws java.rmi.RemoteException;

    /**
     * Returns the request information of requestresponseid
     */
    public GetRequestResponse getRequest(String requestresponseID, String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public String checkUpdate(String username, String password, float lat, float lon) throws java.rmi.RemoteException;

}
