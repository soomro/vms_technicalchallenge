package edu.vms.web;

import javax.xml.rpc.JAXRPCException;
import javax.xml.namespace.QName;
import javax.microedition.xml.rpc.Operation;
import javax.microedition.xml.rpc.Type;
import javax.microedition.xml.rpc.ComplexType;
import javax.microedition.xml.rpc.Element;

public class WS_Stub implements WS, javax.xml.rpc.Stub {

    private String[] _propertyNames;
    private Object[] _propertyValues;

    public WS_Stub() {
        _propertyNames = new String[] { ENDPOINT_ADDRESS_PROPERTY };
        _propertyValues = new Object[] { "http://licrp.dnsalias.net/apollo/ws.asmx" };
    }

    public void _setProperty( String name, Object value ) {
        int size = _propertyNames.length;
        for (int i = 0; i < size; ++i) {
            if( _propertyNames[i].equals( name )) {
                _propertyValues[i] = value;
                return;
            }
        }
        String[] newPropNames = new String[size + 1];
        System.arraycopy(_propertyNames, 0, newPropNames, 0, size);
        _propertyNames = newPropNames;
        Object[] newPropValues = new Object[size + 1];
        System.arraycopy(_propertyValues, 0, newPropValues, 0, size);
        _propertyValues = newPropValues;

        _propertyNames[size] = name;
        _propertyValues[size] = value;
    }

    public Object _getProperty(String name) {
        for (int i = 0; i < _propertyNames.length; ++i) {
            if (_propertyNames[i].equals(name)) {
                return _propertyValues[i];
            }
        }
        if (ENDPOINT_ADDRESS_PROPERTY.equals(name) || USERNAME_PROPERTY.equals(name) || PASSWORD_PROPERTY.equals(name)) {
            return null;
        }
        if (SESSION_MAINTAIN_PROPERTY.equals(name)) {
            return new Boolean(false);
        }
        throw new JAXRPCException("Stub does not recognize property: " + name);
    }

    protected void _prepOperation(Operation op) {
        for (int i = 0; i < _propertyNames.length; ++i) {
            op.setProperty(_propertyNames[i], _propertyValues[i].toString());
        }
    }

    public String login(String username, String password) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            username,
            password
        };

        Operation op = Operation.newInstance( _qname_operation_Login, _type_Login, _type_LoginResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/Login" );
        Object resultObj;
        try {
            resultObj = op.invoke( inputObject );
        } catch( JAXRPCException e ) {
            Throwable cause = e.getLinkedCause();
            if( cause instanceof java.rmi.RemoteException ) {
                throw (java.rmi.RemoteException) cause;
            }
            throw e;
        }

        return (String )((Object[])resultObj)[0];
    }

    public String getRequest(int requestID, String userID) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            new Integer(requestID),
            userID
        };

        Operation op = Operation.newInstance( _qname_operation_GetRequest, _type_GetRequest, _type_GetRequestResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/GetRequest" );
        Object resultObj;
        try {
            resultObj = op.invoke( inputObject );
        } catch( JAXRPCException e ) {
            Throwable cause = e.getLinkedCause();
            if( cause instanceof java.rmi.RemoteException ) {
                throw (java.rmi.RemoteException) cause;
            }
            throw e;
        }

        return (String )((Object[])resultObj)[0];
    }

    public String checkUpdate(String usename, String guid) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            usename,
            guid
        };

        Operation op = Operation.newInstance( _qname_operation_CheckUpdate, _type_CheckUpdate, _type_CheckUpdateResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/CheckUpdate" );
        Object resultObj;
        try {
            resultObj = op.invoke( inputObject );
        } catch( JAXRPCException e ) {
            Throwable cause = e.getLinkedCause();
            if( cause instanceof java.rmi.RemoteException ) {
                throw (java.rmi.RemoteException) cause;
            }
            throw e;
        }

        return (String )((Object[])resultObj)[0];
    }

    public String helloWorld() throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
        };

        Operation op = Operation.newInstance( _qname_operation_HelloWorld, _type_HelloWorld, _type_HelloWorldResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/HelloWorld" );
        Object resultObj;
        try {
            resultObj = op.invoke( inputObject );
        } catch( JAXRPCException e ) {
            Throwable cause = e.getLinkedCause();
            if( cause instanceof java.rmi.RemoteException ) {
                throw (java.rmi.RemoteException) cause;
            }
            throw e;
        }

        return (String )((Object[])resultObj)[0];
    }

    protected static final QName _qname_operation_Login = new QName( "http://tempuri.org/", "Login" );
    protected static final QName _qname_operation_HelloWorld = new QName( "http://tempuri.org/", "HelloWorld" );
    protected static final QName _qname_operation_CheckUpdate = new QName( "http://tempuri.org/", "CheckUpdate" );
    protected static final QName _qname_operation_GetRequest = new QName( "http://tempuri.org/", "GetRequest" );
    protected static final QName _qname_GetRequestResponse = new QName( "http://tempuri.org/", "GetRequestResponse" );
    protected static final QName _qname_HelloWorldResponse = new QName( "http://tempuri.org/", "HelloWorldResponse" );
    protected static final QName _qname_Login = new QName( "http://tempuri.org/", "Login" );
    protected static final QName _qname_CheckUpdate = new QName( "http://tempuri.org/", "CheckUpdate" );
    protected static final QName _qname_HelloWorld = new QName( "http://tempuri.org/", "HelloWorld" );
    protected static final QName _qname_LoginResponse = new QName( "http://tempuri.org/", "LoginResponse" );
    protected static final QName _qname_GetRequest = new QName( "http://tempuri.org/", "GetRequest" );
    protected static final QName _qname_CheckUpdateResponse = new QName( "http://tempuri.org/", "CheckUpdateResponse" );
    protected static final Element _type_GetRequest;
    protected static final Element _type_CheckUpdate;
    protected static final Element _type_GetRequestResponse;
    protected static final Element _type_LoginResponse;
    protected static final Element _type_Login;
    protected static final Element _type_HelloWorldResponse;
    protected static final Element _type_CheckUpdateResponse;
    protected static final Element _type_HelloWorld;

    static {
        _type_HelloWorldResponse = new Element( _qname_HelloWorldResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "HelloWorldResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_GetRequestResponse = new Element( _qname_GetRequestResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "GetRequestResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_Login = new Element( _qname_Login, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_HelloWorld = new Element( _qname_HelloWorld, _complexType( new Element[] {
        }), 1, 1, false );
        _type_CheckUpdate = new Element( _qname_CheckUpdate, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "usename" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "guid" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_CheckUpdateResponse = new Element( _qname_CheckUpdateResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "CheckUpdateResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_GetRequest = new Element( _qname_GetRequest, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "requestID" ), Type.INT ),
            new Element( new QName( "http://tempuri.org/", "userID" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_LoginResponse = new Element( _qname_LoginResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "LoginResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
    }

    private static ComplexType _complexType( Element[] elements ) {
        ComplexType result = new ComplexType();
        result.elements = elements;
        return result;
    }
}
