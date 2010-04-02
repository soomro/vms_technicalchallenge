package service;
import javax.xml.namespace.QName;

public interface Service extends java.rmi.Remote {

    /**
     *
     */
    public String ageCalculate(String name, int birthyear) throws java.rmi.RemoteException;

}
