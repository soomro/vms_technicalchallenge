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

    public boolean login(String username, String password) throws java.rmi.RemoteException {
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

        return ((Boolean )((Object[])resultObj)[0]).booleanValue();
    }

    public GetAlertResponse getAlert(String alertID, String username, String password) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            alertID,
            username,
            password
        };

        Operation op = Operation.newInstance( _qname_operation_GetAlert, _type_GetAlert, _type_GetAlertResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/GetAlert" );
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

        return GetAlertResponse_fromObject((Object[])resultObj);
    }

    public RespondToRequestResponse respondToRequest(String requestresponseID, String username, String password, String amountProvided) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            requestresponseID,
            username,
            password,
            amountProvided
        };

        Operation op = Operation.newInstance( _qname_operation_RespondToRequest, _type_RespondToRequest, _type_RespondToRequestResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/RespondToRequest" );
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

        return RespondToRequestResponse_fromObject((Object[])resultObj);
    }

    public GetRequestResponse getRequest(String requestresponseID, String username, String password) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            requestresponseID,
            username,
            password
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

        return GetRequestResponse_fromObject((Object[])resultObj);
    }

    public String checkUpdate(String username, String password, float lat, float lon) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            username,
            password,
            new Float(lat),
            new Float(lon)
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

    private static RespondToRequestResponse RespondToRequestResponse_fromObject( Object obj[] ) {
        if(obj == null) return null;
        RespondToRequestResponse result = new RespondToRequestResponse();
        result.setRespondToRequestResult(((Boolean )obj[0]).booleanValue());
        result.setMsg((String )obj[1]);
        return result;
    }

    private static GetAlertResponse GetAlertResponse_fromObject( Object obj[] ) {
        if(obj == null) return null;
        GetAlertResponse result = new GetAlertResponse();
        result.setGetAlertResult((String )obj[0]);
        result.setMsg((String )obj[1]);
        return result;
    }

    private static GetRequestResponse GetRequestResponse_fromObject( Object obj[] ) {
        if(obj == null) return null;
        GetRequestResponse result = new GetRequestResponse();
        result.setGetRequestResult((String )obj[0]);
        result.setMsg((String )obj[1]);
        return result;
    }

    protected static final QName _qname_operation_GetAlert = new QName( "http://tempuri.org/", "GetAlert" );
    protected static final QName _qname_operation_Login = new QName( "http://tempuri.org/", "Login" );
    protected static final QName _qname_operation_CheckUpdate = new QName( "http://tempuri.org/", "CheckUpdate" );
    protected static final QName _qname_operation_GetRequest = new QName( "http://tempuri.org/", "GetRequest" );
    protected static final QName _qname_operation_RespondToRequest = new QName( "http://tempuri.org/", "RespondToRequest" );
    protected static final QName _qname_GetAlert = new QName( "http://tempuri.org/", "GetAlert" );
    protected static final QName _qname_GetRequestResponse = new QName( "http://tempuri.org/", "GetRequestResponse" );
    protected static final QName _qname_Login = new QName( "http://tempuri.org/", "Login" );
    protected static final QName _qname_CheckUpdate = new QName( "http://tempuri.org/", "CheckUpdate" );
    protected static final QName _qname_RespondToRequestResponse = new QName( "http://tempuri.org/", "RespondToRequestResponse" );
    protected static final QName _qname_LoginResponse = new QName( "http://tempuri.org/", "LoginResponse" );
    protected static final QName _qname_GetRequest = new QName( "http://tempuri.org/", "GetRequest" );
    protected static final QName _qname_CheckUpdateResponse = new QName( "http://tempuri.org/", "CheckUpdateResponse" );
    protected static final QName _qname_RespondToRequest = new QName( "http://tempuri.org/", "RespondToRequest" );
    protected static final QName _qname_GetAlertResponse = new QName( "http://tempuri.org/", "GetAlertResponse" );
    protected static final Element _type_LoginResponse;
    protected static final Element _type_CheckUpdateResponse;
    protected static final Element _type_Login;
    protected static final Element _type_RespondToRequestResponse;
    protected static final Element _type_GetAlertResponse;
    protected static final Element _type_CheckUpdate;
    protected static final Element _type_RespondToRequest;
    protected static final Element _type_GetRequest;
    protected static final Element _type_GetAlert;
    protected static final Element _type_GetRequestResponse;

    static {
        _type_GetRequestResponse = new Element( _qname_GetRequestResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "GetRequestResult" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "msg" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_GetAlert = new Element( _qname_GetAlert, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "alertID" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_Login = new Element( _qname_Login, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_CheckUpdate = new Element( _qname_CheckUpdate, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "lat" ), Type.FLOAT ),
            new Element( new QName( "http://tempuri.org/", "lon" ), Type.FLOAT )}), 1, 1, false );
        _type_RespondToRequestResponse = new Element( _qname_RespondToRequestResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "RespondToRequestResult" ), Type.BOOLEAN ),
            new Element( new QName( "http://tempuri.org/", "msg" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_CheckUpdateResponse = new Element( _qname_CheckUpdateResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "CheckUpdateResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_GetRequest = new Element( _qname_GetRequest, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "requestresponseID" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_LoginResponse = new Element( _qname_LoginResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "LoginResult" ), Type.BOOLEAN )}), 1, 1, false );
        _type_RespondToRequest = new Element( _qname_RespondToRequest, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "requestresponseID" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "username" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "password" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "amountProvided" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_GetAlertResponse = new Element( _qname_GetAlertResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "GetAlertResult" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "msg" ), Type.STRING, 0, 1, false )}), 1, 1, false );
    }

    private static ComplexType _complexType( Element[] elements ) {
        ComplexType result = new ComplexType();
        result.elements = elements;
        return result;
    }
}
