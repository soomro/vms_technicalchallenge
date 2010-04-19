/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package edu.vms.util;

import edu.vms.ClientMIDlet;
import javax.microedition.lcdui.Canvas;
import javax.microedition.lcdui.Graphics;
import javax.microedition.media.MediaException;
import javax.microedition.media.control.VideoControl;

/**
 *
 * @author tiko
 */
   public class VideoCanvas extends Canvas {
    private ClientMIDlet midlet;

    public VideoCanvas(ClientMIDlet midlet, VideoControl videoControl) {
        int width = getWidth();
        int height = getHeight();
        this.midlet = midlet;

        videoControl.initDisplayMode(VideoControl.USE_DIRECT_VIDEO, this);
        try {
            videoControl.setDisplayLocation(2, 2);
            videoControl.setDisplaySize(width - 4, height - 4);
            videoControl.setVisible(true);
        } catch (MediaException me) {
            me.printStackTrace();}
        
    }

    public void paint(Graphics g) {
        int width = getWidth();
        int height = getHeight();

        g.setColor(255, 0, 0);
        g.drawRect(0, 0, width - 1, height - 1);
        g.drawRect(1, 1, width - 3, height - 3);
    }
}