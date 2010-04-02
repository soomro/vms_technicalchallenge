/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package edu.vms.util;

/**
 *
 * This class is created for manipulating with the text
 * @author tiko
 */
public class TextParser {
    /*
     * s parameter is a text
     * getRequest will pars the s and will return the request containing in text
     */
    public static String getRequest(String s){
        String request = s.substring(s.indexOf(":") + 1, s.indexOf("#A"));
        return request;
    }

    /*
     * s parameter is a text
     * getRequest will pars the s and will return the request ID containing in text
     */
    public static String getRequestID(String s){
        String request = s.substring(s.indexOf("R?") + 2, s.indexOf(":"));
        return request;
    }
}
