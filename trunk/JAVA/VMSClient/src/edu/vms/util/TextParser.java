/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package edu.vms.util;

import edu.vms.ClientMIDlet;
import java.util.Vector;

/**
 *
 * This class is created for manipulating with the text
 * @author tiko
 */
public class TextParser {
    /*
     * s parameter is a text
     * pasrUpdates will pars the s and will return the request containing in text
     */
    public static void pasrUpdates(String s, ClientMIDlet midlet){
        midlet.reqInfo = new Request();
        if(s.trim().equals("")){
            
            return;
        }
        char spc = (char)254;// special character
        char ass = s.substring(0,1).charAt(0);
        System.out.println("ass " + (int)ass);
        s = s.substring(1);
        int index = s.indexOf(spc);
        Request req = midlet.reqInfo;
        int alertI = 0;
        for(; alertI < 5; alertI++){
            if(midlet.alertIDs[alertI].equals("")){
                break;
            }
        }
        boolean isReq = false;
        while(index != -1){
            String type = s.substring(0, index);
            System.out.println("1 : " + s);
            s = s.substring(index + 1);
            System.out.println("2 : " + s);
            index = s.indexOf(spc);
            String ID = s.substring(0, index);
            s = s.substring(index + 1);
            System.out.println("3 : " + s);
            index = s.indexOf(spc);
            String name = s.substring(0, index);
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            if("R".equals(type))
            {
                isReq = true;
                req.ID = ID;
                req.name = name;
            } else {
                midlet.alertIDs[alertI] = ID;
                midlet.alertN[alertI] = name;
                alertI++;
            }
        }
        if(isReq == false){
            if(!midlet.accepted){
                midlet.reqInfo = new Request();
            }
        }
    }

    public static void getRequestInfo(String s, ClientMIDlet midlet){
        char spc = (char)254;// special character
        s = s.substring(1);
        int index = s.indexOf(spc);
        Request req = midlet.reqInfo;
        req.nAmount = new Vector();
        req.nCollected = new Vector();
        req.nType = new Vector();
        req.nUnit = new Vector();
        boolean isAnswered = false;
        if(index != -1){
            req.name = s.substring(0, index);
            System.out.println("1 : " + s);
            s = s.substring(index + 1);
            System.out.println("2 : " + s);
            index = s.indexOf(spc);
            req.location = s.substring(0, index);
            s = s.substring(index + 1);
            System.out.println("3 : " + s);
            index = s.indexOf(spc);
            req.message = s.substring(0, index);
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            while(index != -1){
            req.nType.addElement(s.substring(0, index));
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            req.nUnit.addElement(s.substring(0, index));
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            req.nAmount.addElement(s.substring(0, index));
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            req.nCollected.addElement(s.substring(0, index));
            if(!(req.nCollected.lastElement().equals("") || req.nCollected.lastElement().equals("0"))){
                isAnswered = true;
            }
            s = s.substring(index + 1);
            index = s.indexOf(spc);
            }
            if(isAnswered){
                midlet.accepted = true;
            } else {
                midlet.accepted = false;
            }
        }

    }

    public static String createResponce(ClientMIDlet midlet){
        char spc = (char)254;// special character
        Request req = midlet.reqInfo;
        StringBuffer respoce = new StringBuffer();
        for(int i = 0; i < req.nType.size(); i++){
            respoce.append(spc);
            respoce.append(req.nType.elementAt(i));
            respoce.append(spc);
            respoce.append(req.nCollected.elementAt(i));
            System.out.println("asdasd " + req.nCollected.elementAt(i));
        }
        respoce.append(spc);
        return respoce.toString();
    }

    public static String createResponceForReject(ClientMIDlet midlet){
        char spc = (char)254;// special character
        Request req = midlet.reqInfo;
        StringBuffer respoce = new StringBuffer();
        for(int i = 0; i < req.nType.size(); i++){
            respoce.append(spc);
            respoce.append(req.nType.elementAt(i));
            respoce.append(spc);
            respoce.append("0");
        }
        respoce.append(spc);
        return respoce.toString();
    }
}
