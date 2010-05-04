/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package edu.vms.util;

import java.util.Vector;


/**
 *
 * @author tiko
 */
public class Request {
    public String ID;
    public String name;
    public String location;
    public String message;
    public Vector nType = new Vector();
    public Vector nUnit = new Vector();
    public Vector nAmount = new Vector();
    public Vector nCollected = new Vector();
}
