package edu.vms.web;

import javax.xml.namespace.QName;
public class GetRequestResponse {

    private String getRequestResult;

    public void setGetRequestResult( String getRequestResult ) {
        this.getRequestResult = getRequestResult;
    }

    public String getGetRequestResult() {
        return getRequestResult;
    }

    private String msg;

    public void setMsg( String msg ) {
        this.msg = msg;
    }

    public String getMsg() {
        return msg;
    }

}
