package edu.vms.web;

import javax.xml.namespace.QName;
public class GetAlertResponse {

    private String getAlertResult;

    public void setGetAlertResult( String getAlertResult ) {
        this.getAlertResult = getAlertResult;
    }

    public String getGetAlertResult() {
        return getAlertResult;
    }

    private String msg;

    public void setMsg( String msg ) {
        this.msg = msg;
    }

    public String getMsg() {
        return msg;
    }

}
