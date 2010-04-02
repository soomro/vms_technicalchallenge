package service;

import javax.xml.rpc.JAXRPCException;
import javax.xml.namespace.QName;
import javax.microedition.xml.rpc.Operation;
import javax.microedition.xml.rpc.Type;
import javax.microedition.xml.rpc.ComplexType;
import javax.microedition.xml.rpc.Element;

public class Service_Stub implements Service, javax.xml.rpc.Stub {

    private String[] _propertyNames;
    private Object[] _propertyValues;

    public Service_Stub() {
        _propertyNames = new String[] { ENDPOINT_ADDRESS_PROPERTY };
        _propertyValues = new Object[] { "http://licrp.dnsalias.net/apollo/service.asmx" };
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

    public String ageCalculate(String name, int birthyear) throws java.rmi.RemoteException {
        Object inputObject[] = new Object[] {
            name,
            new Integer(birthyear)
        };

        Operation op = Operation.newInstance( _qname_operation_AgeCalculate, _type_AgeCalculate, _type_AgeCalculateResponse );
        _prepOperation( op );
        op.setProperty( Operation.SOAPACTION_URI_PROPERTY, "http://tempuri.org/AgeCalculate" );
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

    protected static final QName _qname_operation_AgeCalculate = new QName( "http://tempuri.org/", "AgeCalculate" );
    protected static final QName _qname_AgeCalculateResponse = new QName( "http://tempuri.org/", "AgeCalculateResponse" );
    protected static final QName _qname_AgeCalculate = new QName( "http://tempuri.org/", "AgeCalculate" );
    protected static final Element _type_AgeCalculateResponse;
    protected static final Element _type_AgeCalculate;

    static {
        _type_AgeCalculateResponse = new Element( _qname_AgeCalculateResponse, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "AgeCalculateResult" ), Type.STRING, 0, 1, false )}), 1, 1, false );
        _type_AgeCalculate = new Element( _qname_AgeCalculate, _complexType( new Element[] {
            new Element( new QName( "http://tempuri.org/", "name" ), Type.STRING, 0, 1, false ),
            new Element( new QName( "http://tempuri.org/", "birthyear" ), Type.INT )}), 1, 1, false );
    }

    private static ComplexType _complexType( Element[] elements ) {
        ComplexType result = new ComplexType();
        result.elements = elements;
        return result;
    }
}
