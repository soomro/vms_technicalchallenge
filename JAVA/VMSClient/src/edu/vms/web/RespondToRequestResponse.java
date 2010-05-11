package edu.vms.web;

import javax.xml.namespace.QName;
public class RespondToRequestResponse {

    private boolean respondToRequestResult;

    public void setRespondToRequestResult( boolean respondToRequestResult ) {
        this.respondToRequestResult = respondToRequestResult;
    }

    public boolean getRespondToRequestResult() {
        return respondToRequestResult;
    }

    private String msg;

    public void setMsg( String msg ) {
        this.msg = msg;
    }

    public String getMsg() {
        return msg;
    }

}
