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
     * Used to report the progress of incidents
     */
    public String progressReport(String requestresponseID, String message, int status, String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public RespondToRequestResponse respondToRequest(String requestresponseID, String username, String password, String amountProvided) throws java.rmi.RemoteException;

    /**
     * Used to report new incidents
     */
    public String incidentReport(String message, String location, int typeOfIncident, String username, String password) throws java.rmi.RemoteException;

    /**
     * Returns the request information of requestresponseid
     */
    public GetRequestResponse getRequest(String requestresponseID, String username, String password) throws java.rmi.RemoteException;

    /**
     *
     */
    public String checkUpdate(String username, String password, float lat, float lon) throws java.rmi.RemoteException;

}
