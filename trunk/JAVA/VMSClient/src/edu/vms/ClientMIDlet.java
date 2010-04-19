/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms;

import edu.vms.util.VMSUtilities;
import edu.vms.util.VideoCanvas;
import java.io.IOException;
import java.util.Vector;
import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import javax.microedition.media.Manager;
import javax.microedition.media.MediaException;
import javax.microedition.media.Player;
import javax.microedition.media.control.VideoControl;
import org.netbeans.microedition.lcdui.LoginScreen;
import org.netbeans.microedition.lcdui.WaitScreen;

/**
 * @author tiko
 */
public class ClientMIDlet extends MIDlet implements CommandListener, ItemCommandListener {

    private boolean midletPaused = false;
    //<editor-fold defaultstate="collapsed" desc=" Generated Fields ">//GEN-BEGIN:|fields|0|
    private Command exitCommand;
    private Command exitLogin;
    private Command okCommand;
    private Command acceptCommand;
    private Command rejectCommand;
    private Command reportCommand;
    private Command cancelCommand;
    private Command sendProgressCommand;
    private Command cancelCommand1;
    private Command logoutCommand;
    private Command progressCommand;
    private Command videoCommand;
    private Command sendCommand;
    private Command backCommand;
    private Command okCommand1;
    private Form main;
    private ChoiceGroup choiceGroup;
    private Spacer spacer;
    private ChoiceGroup choiceGroup2;
    private LoginScreen Login;
    private WaitScreen waitScreen;
    private Form request;
    private Form reportIncident;
    private TextField textField;
    private TextField textField1;
    private TextField textField2;
    private Form reportProgress;
    private TextField textField3;
    private TextField textField4;
    private Form viewRequest;
    private Alert alert;
    private Ticker ticker;
    private Image image1;
    //</editor-fold>//GEN-END:|fields|0|
    private VMSUtilities util;
    public boolean loggedIn = false;
    public boolean accepted = false;
    public int requestID;
    public int[] alertIDs = {0, 0, 0, 0, 0};
    public String guid;
    public Vector collectedAmount;
    private Player player;
    private VideoControl videoControl;
    private Video video;
    private Display display;
    private Form form;
    private Command exit, back, capture, camera;
    public String location;
    /*
     * Static variables
     */
    public static Command SUCCESS_LOGIN = new Command("Successful login", 1, 1);

    /**
     * The ClientMIDlet constructor.
     */
    public ClientMIDlet() {
        util = new VMSUtilities(this);
    }

    //<editor-fold defaultstate="collapsed" desc=" Generated Methods ">//GEN-BEGIN:|methods|0|
    //</editor-fold>//GEN-END:|methods|0|
    //<editor-fold defaultstate="collapsed" desc=" Generated Method: initialize ">//GEN-BEGIN:|0-initialize|0|0-preInitialize
    /**
     * Initilizes the application.
     * It is called only once when the MIDlet is started. The method is called before the <code>startMIDlet</code> method.
     */
    private void initialize() {//GEN-END:|0-initialize|0|0-preInitialize
        // write pre-initialize user code here
//GEN-LINE:|0-initialize|1|0-postInitialize
        // write post-initialize user code here
    }//GEN-BEGIN:|0-initialize|2|
    //</editor-fold>//GEN-END:|0-initialize|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: startMIDlet ">//GEN-BEGIN:|3-startMIDlet|0|3-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Started point.
     */
    public void startMIDlet() {//GEN-END:|3-startMIDlet|0|3-preAction
        // write pre-action user code here
        switchDisplayable(null, getLogin());//GEN-LINE:|3-startMIDlet|1|3-postAction
        // write post-action user code here
    }//GEN-BEGIN:|3-startMIDlet|2|
    //</editor-fold>//GEN-END:|3-startMIDlet|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: resumeMIDlet ">//GEN-BEGIN:|4-resumeMIDlet|0|4-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Resumed point.
     */
    public void resumeMIDlet() {//GEN-END:|4-resumeMIDlet|0|4-preAction
        // write pre-action user code here
        switchDisplayable(null, getWaitScreen());//GEN-LINE:|4-resumeMIDlet|1|4-postAction
        // write post-action user code here
    }//GEN-BEGIN:|4-resumeMIDlet|2|
    //</editor-fold>//GEN-END:|4-resumeMIDlet|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: switchDisplayable ">//GEN-BEGIN:|5-switchDisplayable|0|5-preSwitch
    /**
     * Switches a current displayable in a display. The <code>display</code> instance is taken from <code>getDisplay</code> method. This method is used by all actions in the design for switching displayable.
     * @param alert the Alert which is temporarily set to the display; if <code>null</code>, then <code>nextDisplayable</code> is set immediately
     * @param nextDisplayable the Displayable to be set
     */
    public void switchDisplayable(Alert alert, Displayable nextDisplayable) {//GEN-END:|5-switchDisplayable|0|5-preSwitch
        // write pre-switch user code here
        Display display = getDisplay();//GEN-BEGIN:|5-switchDisplayable|1|5-postSwitch
        if (alert == null) {
            display.setCurrent(nextDisplayable);
        } else {
            display.setCurrent(alert, nextDisplayable);
        }//GEN-END:|5-switchDisplayable|1|5-postSwitch
        // write post-switch user code here
    }//GEN-BEGIN:|5-switchDisplayable|2|
    //</editor-fold>//GEN-END:|5-switchDisplayable|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: commandAction for Displayables ">//GEN-BEGIN:|7-commandAction|0|7-preCommandAction
    /**
     * Called by a system to indicated that a command has been invoked on a particular displayable.
     * @param command the Command that was invoked
     * @param displayable the Displayable where the command was invoked
     */
    public void commandAction(Command command, Displayable displayable) {//GEN-END:|7-commandAction|0|7-preCommandAction
        // write pre-action user code here
        if (displayable == Login) {//GEN-BEGIN:|7-commandAction|1|24-preAction
            if (command == LoginScreen.LOGIN_COMMAND) {//GEN-END:|7-commandAction|1|24-preAction
                // write pre-action user code here
                switchDisplayable(null, getWaitScreen());//GEN-LINE:|7-commandAction|2|24-postAction
                //checking of the valid username and password
                util.checkUsernameAndPassword(Login.getUsername(), Login.getPassword());
                // write post-action user code here
            } else if (command == exitLogin) {//GEN-LINE:|7-commandAction|3|30-preAction
                // write pre-action user code here
                exitMIDlet();//GEN-LINE:|7-commandAction|4|30-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|5|132-preAction
        } else if (displayable == alert) {
            if (command == okCommand1) {//GEN-END:|7-commandAction|5|132-preAction
                // write pre-action user code here
//GEN-LINE:|7-commandAction|6|132-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|7|19-preAction
        } else if (displayable == main) {
            if (command == exitCommand) {//GEN-END:|7-commandAction|7|19-preAction
                // write pre-action user code here
                exitMIDlet();//GEN-LINE:|7-commandAction|8|19-postAction
                // write post-action user code here
            } else if (command == logoutCommand) {//GEN-LINE:|7-commandAction|9|109-preAction
                // write pre-action user code here
                switchDisplayable(null, getLogin());//GEN-LINE:|7-commandAction|10|109-postAction
                util.logout();
                // write post-action user code here
            } else if (command == progressCommand) {//GEN-LINE:|7-commandAction|11|105-preAction
                // write pre-action user code here
                switchDisplayable(null, getReportProgress());//GEN-LINE:|7-commandAction|12|105-postAction
                // write post-action user code here
            } else if (command == reportCommand) {//GEN-LINE:|7-commandAction|13|88-preAction
                // write pre-action user code here
                switchDisplayable(null, getReportIncident());//GEN-LINE:|7-commandAction|14|88-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|15|94-preAction
        } else if (displayable == reportIncident) {
            if (command == cancelCommand) {//GEN-END:|7-commandAction|15|94-preAction
                // write pre-action user code here
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|16|94-postAction
                // write post-action user code here
            } else if (command == sendCommand) {//GEN-LINE:|7-commandAction|17|117-preAction
                // write pre-action user code here
                util.sendReport();
//GEN-LINE:|7-commandAction|18|117-postAction
                // write post-action user code here
            } else if (command == videoCommand) {//GEN-LINE:|7-commandAction|19|113-preAction
                // write pre-action user code here
                showCamera();
//GEN-LINE:|7-commandAction|20|113-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|21|97-preAction
        } else if (displayable == reportProgress) {
            if (command == cancelCommand1) {//GEN-END:|7-commandAction|21|97-preAction
                // write pre-action user code here
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|22|97-postAction
                // write post-action user code here
            } else if (command == sendProgressCommand) {//GEN-LINE:|7-commandAction|23|103-preAction
                // write pre-action user code here
//GEN-LINE:|7-commandAction|24|103-postAction
                util.sendProgress();
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|25|78-preAction
        } else if (displayable == request) {
            if (command == acceptCommand) {//GEN-END:|7-commandAction|25|78-preAction
                // write pre-action user code here
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|26|78-postAction
                util.acceptRequest();
                // write post-action user code here
            } else if (command == rejectCommand) {//GEN-LINE:|7-commandAction|27|80-preAction
                // write pre-action user code here
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|28|80-postAction
                util.removeRequest();
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|29|120-preAction
        } else if (displayable == viewRequest) {
            if (command == backCommand) {//GEN-END:|7-commandAction|29|120-preAction
                // write pre-action user code here
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|30|120-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|31|50-preAction
        } else if (displayable == waitScreen) {
            if (command == WaitScreen.FAILURE_COMMAND) {//GEN-END:|7-commandAction|31|50-preAction
                // write pre-action user code here
                switchDisplayable(null, getLogin());
//GEN-LINE:|7-commandAction|32|50-postAction
                // write post-action user code here
            } else if (command == WaitScreen.SUCCESS_COMMAND) {//GEN-LINE:|7-commandAction|33|49-preAction
                // write pre-action user code here
                if (loggedIn) {
                    switchDisplayable(null, getMain());
                } else {
                    switchDisplayable(null, getLogin());
                }
//GEN-LINE:|7-commandAction|34|49-postAction
                // write post-action user code here
            } else if (command == ClientMIDlet.SUCCESS_LOGIN) {
                switchDisplayable(null, getMain());
                util.checkPeriodically();
            }//GEN-BEGIN:|7-commandAction|35|7-postCommandAction
        }//GEN-END:|7-commandAction|35|7-postCommandAction
        // write post-action user code here
    }//GEN-BEGIN:|7-commandAction|36|
    //</editor-fold>//GEN-END:|7-commandAction|36|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: exitCommand ">//GEN-BEGIN:|18-getter|0|18-preInit
    /**
     * Returns an initiliazed instance of exitCommand component.
     * @return the initialized component instance
     */
    public Command getExitCommand() {
        if (exitCommand == null) {//GEN-END:|18-getter|0|18-preInit
            // write pre-init user code here
            exitCommand = new Command("Exit", Command.EXIT, 5);//GEN-LINE:|18-getter|1|18-postInit
            // write post-init user code here
        }//GEN-BEGIN:|18-getter|2|
        return exitCommand;
    }
    //</editor-fold>//GEN-END:|18-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: main ">//GEN-BEGIN:|14-getter|0|14-preInit
    /**
     * Returns an initiliazed instance of main component.
     * @return the initialized component instance
     */
    public Form getMain() {
        if (main == null) {//GEN-END:|14-getter|0|14-preInit
            // write pre-init user code here
            main = new Form("VMS Main", new Item[] { getChoiceGroup(), getSpacer(), getChoiceGroup2() });//GEN-BEGIN:|14-getter|1|14-postInit
            main.addCommand(getExitCommand());
            main.addCommand(getReportCommand());
            main.addCommand(getProgressCommand());
            main.addCommand(getLogoutCommand());
            main.setCommandListener(this);//GEN-END:|14-getter|1|14-postInit
            // write post-init user code here
        }//GEN-BEGIN:|14-getter|2|
        return main;
    }
    //</editor-fold>//GEN-END:|14-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: exitLogin ">//GEN-BEGIN:|29-getter|0|29-preInit
    /**
     * Returns an initiliazed instance of exitLogin component.
     * @return the initialized component instance
     */
    public Command getExitLogin() {
        if (exitLogin == null) {//GEN-END:|29-getter|0|29-preInit
            // write pre-init user code here
            exitLogin = new Command("Exit", "Exit", Command.EXIT, 0);//GEN-LINE:|29-getter|1|29-postInit
            // write post-init user code here
        }//GEN-BEGIN:|29-getter|2|
        return exitLogin;
    }
    //</editor-fold>//GEN-END:|29-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: Login ">//GEN-BEGIN:|22-getter|0|22-preInit
    /**
     * Returns an initiliazed instance of Login component.
     * @return the initialized component instance
     */
    public LoginScreen getLogin() {
        if (Login == null) {//GEN-END:|22-getter|0|22-preInit
            // write pre-init user code here
            Login = new LoginScreen(getDisplay());//GEN-BEGIN:|22-getter|1|22-postInit
            Login.setLabelTexts("Username", "Password");
            Login.setTitle("VMS Login");
            Login.setTicker(getTicker());
            Login.addCommand(LoginScreen.LOGIN_COMMAND);
            Login.addCommand(getExitLogin());
            Login.setCommandListener(this);
            Login.setBGColor(-39322);
            Login.setFGColor(0);
            Login.setLoginTitle("Login to VMS");
            Login.setUseLoginButton(true);
            Login.setLoginButtonText("Login");//GEN-END:|22-getter|1|22-postInit
            // write post-init user code here
        }//GEN-BEGIN:|22-getter|2|
        return Login;
    }
    //</editor-fold>//GEN-END:|22-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: ticker ">//GEN-BEGIN:|36-getter|0|36-preInit
    /**
     * Returns an initiliazed instance of ticker component.
     * @return the initialized component instance
     */
    public Ticker getTicker() {
        if (ticker == null) {//GEN-END:|36-getter|0|36-preInit
            // write pre-init user code here
            ticker = new Ticker("");//GEN-LINE:|36-getter|1|36-postInit
            // write post-init user code here
        }//GEN-BEGIN:|36-getter|2|
        return ticker;
    }
    //</editor-fold>//GEN-END:|36-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: waitScreen ">//GEN-BEGIN:|48-getter|0|48-preInit
    /**
     * Returns an initiliazed instance of waitScreen component.
     * @return the initialized component instance
     */
    public WaitScreen getWaitScreen() {
        if (waitScreen == null) {//GEN-END:|48-getter|0|48-preInit
            // write pre-init user code here
            waitScreen = new WaitScreen(getDisplay());//GEN-BEGIN:|48-getter|1|48-postInit
            waitScreen.setTitle("waitScreen");
            waitScreen.setCommandListener(this);
            waitScreen.setFullScreenMode(true);//GEN-END:|48-getter|1|48-postInit
            // write post-init user code here
        }//GEN-BEGIN:|48-getter|2|
        return waitScreen;
    }
    //</editor-fold>//GEN-END:|48-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: choiceGroup ">//GEN-BEGIN:|62-getter|0|62-preInit
    /**
     * Returns an initiliazed instance of choiceGroup component.
     * @return the initialized component instance
     */
    public ChoiceGroup getChoiceGroup() {
        if (choiceGroup == null) {//GEN-END:|62-getter|0|62-preInit
            // write pre-init user code here
            choiceGroup = new ChoiceGroup("Requests", Choice.MULTIPLE);//GEN-BEGIN:|62-getter|1|62-postInit
            choiceGroup.append("", null);
            choiceGroup.addCommand(getOkCommand());
            choiceGroup.setItemCommandListener(this);
            choiceGroup.setLayout(ImageItem.LAYOUT_CENTER);
            choiceGroup.setFitPolicy(Choice.TEXT_WRAP_DEFAULT);
            choiceGroup.setSelectedFlags(new boolean[] { false });//GEN-END:|62-getter|1|62-postInit
            // write post-init user code here
        }//GEN-BEGIN:|62-getter|2|
        return choiceGroup;
    }
    //</editor-fold>//GEN-END:|62-getter|2|



    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: spacer ">//GEN-BEGIN:|65-getter|0|65-preInit
    /**
     * Returns an initiliazed instance of spacer component.
     * @return the initialized component instance
     */
    public Spacer getSpacer() {
        if (spacer == null) {//GEN-END:|65-getter|0|65-preInit
            // write pre-init user code here
            spacer = new Spacer(16, 5);//GEN-LINE:|65-getter|1|65-postInit
            // write post-init user code here
        }//GEN-BEGIN:|65-getter|2|
        return spacer;
    }
    //</editor-fold>//GEN-END:|65-getter|2|



    //<editor-fold defaultstate="collapsed" desc=" Generated Method: commandAction for Items ">//GEN-BEGIN:|17-itemCommandAction|0|17-preItemCommandAction
    /**
     * Called by a system to indicated that a command has been invoked on a particular item.
     * @param command the Command that was invoked
     * @param displayable the Item where the command was invoked
     */
    public void commandAction(Command command, Item item) {//GEN-END:|17-itemCommandAction|0|17-preItemCommandAction
        // write pre-action user code here
        if (item == choiceGroup) {//GEN-BEGIN:|17-itemCommandAction|1|69-preAction
            if (command == okCommand) {//GEN-END:|17-itemCommandAction|1|69-preAction
                // write pre-action user code here
                if (getChoiceGroup().isSelected(0)) {
//GEN-LINE:|17-itemCommandAction|2|69-postAction
                    System.out.println("accepted = " + accepted);
                    if (accepted) {
                        switchDisplayable(null, getViewRequest());
                        String[] iName = {"Car/ Item"};
                        int[] iNumber = {5};
                        String location = "Angered Centre";
                        String message = "Hello, we need your help";
                        String name = "Angered disaster";
                        util.drawViewRequest(location, name, message, iName, iNumber);

                    } else {
                        switchDisplayable(null, getRequest());
                        util.getRequestInfo();
                    }
                }// write post-action user code here
            }//GEN-BEGIN:|17-itemCommandAction|3|139-preAction
        } else if (item == choiceGroup2) {
            if (command == okCommand) {//GEN-END:|17-itemCommandAction|3|139-preAction
                // write pre-action user code here
                int selectedIndex = choiceGroup2.getSelectedIndex();
                if(alertIDs[selectedIndex] != 0){
                    // shold get and show the alert here
                }
//GEN-LINE:|17-itemCommandAction|4|139-postAction
                // write post-action user code here
            }//GEN-BEGIN:|17-itemCommandAction|5|17-postItemCommandAction
        }//GEN-END:|17-itemCommandAction|5|17-postItemCommandAction
        // write post-action user code here
    }//GEN-BEGIN:|17-itemCommandAction|6|
    //</editor-fold>//GEN-END:|17-itemCommandAction|6|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: okCommand ">//GEN-BEGIN:|68-getter|0|68-preInit
    /**
     * Returns an initiliazed instance of okCommand component.
     * @return the initialized component instance
     */
    public Command getOkCommand() {
        if (okCommand == null) {//GEN-END:|68-getter|0|68-preInit
            // write pre-init user code here
            okCommand = new Command("Open", Command.OK, 4);//GEN-LINE:|68-getter|1|68-postInit
            // write post-init user code here
        }//GEN-BEGIN:|68-getter|2|
        return okCommand;
    }
    //</editor-fold>//GEN-END:|68-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: request ">//GEN-BEGIN:|70-getter|0|70-preInit
    /**
     * Returns an initiliazed instance of request component.
     * @return the initialized component instance
     */
    public Form getRequest() {
        if (request == null) {//GEN-END:|70-getter|0|70-preInit
            // write pre-init user code here
            request = new Form("Request info", new Item[] { });//GEN-BEGIN:|70-getter|1|70-postInit
            request.addCommand(getAcceptCommand());
            request.addCommand(getRejectCommand());
            request.setCommandListener(this);//GEN-END:|70-getter|1|70-postInit
            // write post-init user code here
        }//GEN-BEGIN:|70-getter|2|
        return request;
    }
    //</editor-fold>//GEN-END:|70-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: acceptCommand ">//GEN-BEGIN:|77-getter|0|77-preInit
    /**
     * Returns an initiliazed instance of acceptCommand component.
     * @return the initialized component instance
     */
    public Command getAcceptCommand() {
        if (acceptCommand == null) {//GEN-END:|77-getter|0|77-preInit
            // write pre-init user code here
            acceptCommand = new Command("Accept", Command.OK, 0);//GEN-LINE:|77-getter|1|77-postInit
            // write post-init user code here
        }//GEN-BEGIN:|77-getter|2|
        return acceptCommand;
    }
    //</editor-fold>//GEN-END:|77-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: rejectCommand ">//GEN-BEGIN:|79-getter|0|79-preInit
    /**
     * Returns an initiliazed instance of rejectCommand component.
     * @return the initialized component instance
     */
    public Command getRejectCommand() {
        if (rejectCommand == null) {//GEN-END:|79-getter|0|79-preInit
            // write pre-init user code here
            rejectCommand = new Command("Reject", Command.OK, 0);//GEN-LINE:|79-getter|1|79-postInit
            // write post-init user code here
        }//GEN-BEGIN:|79-getter|2|
        return rejectCommand;
    }
    //</editor-fold>//GEN-END:|79-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: reportCommand ">//GEN-BEGIN:|87-getter|0|87-preInit
    /**
     * Returns an initiliazed instance of reportCommand component.
     * @return the initialized component instance
     */
    public Command getReportCommand() {
        if (reportCommand == null) {//GEN-END:|87-getter|0|87-preInit
            // write pre-init user code here
            reportCommand = new Command("Report", "Report Incident", Command.OK, 1);//GEN-LINE:|87-getter|1|87-postInit
            // write post-init user code here
        }//GEN-BEGIN:|87-getter|2|
        return reportCommand;
    }
    //</editor-fold>//GEN-END:|87-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: cancelCommand ">//GEN-BEGIN:|93-getter|0|93-preInit
    /**
     * Returns an initiliazed instance of cancelCommand component.
     * @return the initialized component instance
     */
    public Command getCancelCommand() {
        if (cancelCommand == null) {//GEN-END:|93-getter|0|93-preInit
            // write pre-init user code here
            cancelCommand = new Command("Cancel", Command.CANCEL, 0);//GEN-LINE:|93-getter|1|93-postInit
            // write post-init user code here
        }//GEN-BEGIN:|93-getter|2|
        return cancelCommand;
    }
    //</editor-fold>//GEN-END:|93-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: cancelCommand1 ">//GEN-BEGIN:|96-getter|0|96-preInit
    /**
     * Returns an initiliazed instance of cancelCommand1 component.
     * @return the initialized component instance
     */
    public Command getCancelCommand1() {
        if (cancelCommand1 == null) {//GEN-END:|96-getter|0|96-preInit
            // write pre-init user code here
            cancelCommand1 = new Command("Cancel", Command.CANCEL, 0);//GEN-LINE:|96-getter|1|96-postInit
            // write post-init user code here
        }//GEN-BEGIN:|96-getter|2|
        return cancelCommand1;
    }
    //</editor-fold>//GEN-END:|96-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: sendProgressCommand ">//GEN-BEGIN:|102-getter|0|102-preInit
    /**
     * Returns an initiliazed instance of sendProgressCommand component.
     * @return the initialized component instance
     */
    public Command getSendProgressCommand() {
        if (sendProgressCommand == null) {//GEN-END:|102-getter|0|102-preInit
            // write pre-init user code here
            sendProgressCommand = new Command("Send", Command.OK, 0);//GEN-LINE:|102-getter|1|102-postInit
            // write post-init user code here
        }//GEN-BEGIN:|102-getter|2|
        return sendProgressCommand;
    }
    //</editor-fold>//GEN-END:|102-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: progressCommand ">//GEN-BEGIN:|104-getter|0|104-preInit
    /**
     * Returns an initiliazed instance of progressCommand component.
     * @return the initialized component instance
     */
    public Command getProgressCommand() {
        if (progressCommand == null) {//GEN-END:|104-getter|0|104-preInit
            // write pre-init user code here
            progressCommand = new Command("Progress", Command.OK, 1);//GEN-LINE:|104-getter|1|104-postInit
            // write post-init user code here
        }//GEN-BEGIN:|104-getter|2|
        return progressCommand;
    }
    //</editor-fold>//GEN-END:|104-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: reportIncident ">//GEN-BEGIN:|85-getter|0|85-preInit
    /**
     * Returns an initiliazed instance of reportIncident component.
     * @return the initialized component instance
     */
    public Form getReportIncident() {
        if (reportIncident == null) {//GEN-END:|85-getter|0|85-preInit
            // write pre-init user code here
            reportIncident = new Form("Report Incident", new Item[] { getTextField(), getTextField1(), getTextField2() });//GEN-BEGIN:|85-getter|1|85-postInit
            reportIncident.addCommand(getCancelCommand());
            reportIncident.addCommand(getVideoCommand());
            reportIncident.addCommand(getSendCommand());
            reportIncident.setCommandListener(this);//GEN-END:|85-getter|1|85-postInit
            // write post-init user code here
        }//GEN-BEGIN:|85-getter|2|
        return reportIncident;
    }
    //</editor-fold>//GEN-END:|85-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: reportProgress ">//GEN-BEGIN:|86-getter|0|86-preInit
    /**
     * Returns an initiliazed instance of reportProgress component.
     * @return the initialized component instance
     */
    public Form getReportProgress() {
        if (reportProgress == null) {//GEN-END:|86-getter|0|86-preInit
            // write pre-init user code here
            reportProgress = new Form("Progress report", new Item[] { getTextField3(), getTextField4() });//GEN-BEGIN:|86-getter|1|86-postInit
            reportProgress.addCommand(getCancelCommand1());
            reportProgress.addCommand(getSendProgressCommand());
            reportProgress.setCommandListener(this);//GEN-END:|86-getter|1|86-postInit
            // write post-init user code here
        }//GEN-BEGIN:|86-getter|2|
        return reportProgress;
    }
    //</editor-fold>//GEN-END:|86-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: logoutCommand ">//GEN-BEGIN:|108-getter|0|108-preInit
    /**
     * Returns an initiliazed instance of logoutCommand component.
     * @return the initialized component instance
     */
    public Command getLogoutCommand() {
        if (logoutCommand == null) {//GEN-END:|108-getter|0|108-preInit
            // write pre-init user code here
            logoutCommand = new Command("Logout", Command.OK, 0);//GEN-LINE:|108-getter|1|108-postInit
            // write post-init user code here
        }//GEN-BEGIN:|108-getter|2|
        return logoutCommand;
    }
    //</editor-fold>//GEN-END:|108-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: videoCommand ">//GEN-BEGIN:|112-getter|0|112-preInit
    /**
     * Returns an initiliazed instance of videoCommand component.
     * @return the initialized component instance
     */
    public Command getVideoCommand() {
        if (videoCommand == null) {//GEN-END:|112-getter|0|112-preInit
            // write pre-init user code here
            videoCommand = new Command("Video", Command.OK, 0);//GEN-LINE:|112-getter|1|112-postInit
            // write post-init user code here
        }//GEN-BEGIN:|112-getter|2|
        return videoCommand;
    }
    //</editor-fold>//GEN-END:|112-getter|2|



    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: sendCommand ">//GEN-BEGIN:|116-getter|0|116-preInit
    /**
     * Returns an initiliazed instance of sendCommand component.
     * @return the initialized component instance
     */
    public Command getSendCommand() {
        if (sendCommand == null) {//GEN-END:|116-getter|0|116-preInit
            // write pre-init user code here
            sendCommand = new Command("Send", "Send ", Command.OK, 0);//GEN-LINE:|116-getter|1|116-postInit
            // write post-init user code here
        }//GEN-BEGIN:|116-getter|2|
        return sendCommand;
    }
    //</editor-fold>//GEN-END:|116-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: backCommand ">//GEN-BEGIN:|119-getter|0|119-preInit
    /**
     * Returns an initiliazed instance of backCommand component.
     * @return the initialized component instance
     */
    public Command getBackCommand() {
        if (backCommand == null) {//GEN-END:|119-getter|0|119-preInit
            // write pre-init user code here
            backCommand = new Command("Back", Command.BACK, 0);//GEN-LINE:|119-getter|1|119-postInit
            // write post-init user code here
        }//GEN-BEGIN:|119-getter|2|
        return backCommand;
    }
    //</editor-fold>//GEN-END:|119-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: viewRequest ">//GEN-BEGIN:|118-getter|0|118-preInit
    /**
     * Returns an initiliazed instance of viewRequest component.
     * @return the initialized component instance
     */
    public Form getViewRequest() {
        if (viewRequest == null) {//GEN-END:|118-getter|0|118-preInit
            // write pre-init user code here
            viewRequest = new Form("View Request");//GEN-BEGIN:|118-getter|1|118-postInit
            viewRequest.addCommand(getBackCommand());
            viewRequest.setCommandListener(this);//GEN-END:|118-getter|1|118-postInit
            // write post-init user code here
        }//GEN-BEGIN:|118-getter|2|
        return viewRequest;
    }
    //</editor-fold>//GEN-END:|118-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField ">//GEN-BEGIN:|122-getter|0|122-preInit
    /**
     * Returns an initiliazed instance of textField component.
     * @return the initialized component instance
     */
    public TextField getTextField() {
        if (textField == null) {//GEN-END:|122-getter|0|122-preInit
            // write pre-init user code here
            textField = new TextField("Location", null, 32, TextField.ANY);//GEN-LINE:|122-getter|1|122-postInit
            // write post-init user code here
        }//GEN-BEGIN:|122-getter|2|
        return textField;
    }
    //</editor-fold>//GEN-END:|122-getter|2|



    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField1 ">//GEN-BEGIN:|124-getter|0|124-preInit
    /**
     * Returns an initiliazed instance of textField1 component.
     * @return the initialized component instance
     */
    public TextField getTextField1() {
        if (textField1 == null) {//GEN-END:|124-getter|0|124-preInit
            // write pre-init user code here
            textField1 = new TextField("Incident type", null, 32, TextField.ANY);//GEN-LINE:|124-getter|1|124-postInit
            // write post-init user code here
        }//GEN-BEGIN:|124-getter|2|
        return textField1;
    }
    //</editor-fold>//GEN-END:|124-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField2 ">//GEN-BEGIN:|125-getter|0|125-preInit
    /**
     * Returns an initiliazed instance of textField2 component.
     * @return the initialized component instance
     */
    public TextField getTextField2() {
        if (textField2 == null) {//GEN-END:|125-getter|0|125-preInit
            // write pre-init user code here
            textField2 = new TextField("Message to the manager", null, 32, TextField.ANY);//GEN-LINE:|125-getter|1|125-postInit
            // write post-init user code here
        }//GEN-BEGIN:|125-getter|2|
        return textField2;
    }
    //</editor-fold>//GEN-END:|125-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField3 ">//GEN-BEGIN:|126-getter|0|126-preInit
    /**
     * Returns an initiliazed instance of textField3 component.
     * @return the initialized component instance
     */
    public TextField getTextField3() {
        if (textField3 == null) {//GEN-END:|126-getter|0|126-preInit
            // write pre-init user code here
            textField3 = new TextField("Progress (from 0 to 100)", null, 32, TextField.NUMERIC | TextField.NON_PREDICTIVE);//GEN-LINE:|126-getter|1|126-postInit
            // write post-init user code here
        }//GEN-BEGIN:|126-getter|2|
        return textField3;
    }
    //</editor-fold>//GEN-END:|126-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField4 ">//GEN-BEGIN:|127-getter|0|127-preInit
    /**
     * Returns an initiliazed instance of textField4 component.
     * @return the initialized component instance
     */
    public TextField getTextField4() {
        if (textField4 == null) {//GEN-END:|127-getter|0|127-preInit
            // write pre-init user code here
            textField4 = new TextField("Message", null, 32, TextField.ANY);//GEN-LINE:|127-getter|1|127-postInit
            // write post-init user code here
        }//GEN-BEGIN:|127-getter|2|
        return textField4;
    }
    //</editor-fold>//GEN-END:|127-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: okCommand1 ">//GEN-BEGIN:|131-getter|0|131-preInit
    /**
     * Returns an initiliazed instance of okCommand1 component.
     * @return the initialized component instance
     */
    public Command getOkCommand1() {
        if (okCommand1 == null) {//GEN-END:|131-getter|0|131-preInit
            // write pre-init user code here
            okCommand1 = new Command("Ok", Command.OK, 0);//GEN-LINE:|131-getter|1|131-postInit
            // write post-init user code here
        }//GEN-BEGIN:|131-getter|2|
        return okCommand1;
    }
    //</editor-fold>//GEN-END:|131-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: choiceGroup2 ">//GEN-BEGIN:|135-getter|0|135-preInit
    /**
     * Returns an initiliazed instance of choiceGroup2 component.
     * @return the initialized component instance
     */
    public ChoiceGroup getChoiceGroup2() {
        if (choiceGroup2 == null) {//GEN-END:|135-getter|0|135-preInit
            // write pre-init user code here
            choiceGroup2 = new ChoiceGroup("Alerts", Choice.EXCLUSIVE);//GEN-BEGIN:|135-getter|1|135-postInit
            choiceGroup2.append("", null);
            choiceGroup2.append("", null);
            choiceGroup2.append("", null);
            choiceGroup2.append("", null);
            choiceGroup2.append("", null);
            choiceGroup2.addCommand(getOkCommand());
            choiceGroup2.setItemCommandListener(this);
            choiceGroup2.setDefaultCommand(getOkCommand());
            choiceGroup2.setSelectedFlags(new boolean[] { false, false, false, false, false });//GEN-END:|135-getter|1|135-postInit
            // write post-init user code here
        }//GEN-BEGIN:|135-getter|2|
        return choiceGroup2;
    }
    //</editor-fold>//GEN-END:|135-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: alert ">//GEN-BEGIN:|129-getter|0|129-preInit
    /**
     * Returns an initiliazed instance of alert component.
     * @return the initialized component instance
     */
    public Alert getAlert() {
        if (alert == null) {//GEN-END:|129-getter|0|129-preInit
            // write pre-init user code here
            alert = new Alert("alert");//GEN-BEGIN:|129-getter|1|129-postInit
            alert.addCommand(getOkCommand1());
            alert.setCommandListener(this);
            alert.setTimeout(Alert.FOREVER);//GEN-END:|129-getter|1|129-postInit
            // write post-init user code here
        }//GEN-BEGIN:|129-getter|2|
        return alert;
    }
    //</editor-fold>//GEN-END:|129-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: image1 ">//GEN-BEGIN:|130-getter|0|130-preInit
    /**
     * Returns an initiliazed instance of image1 component.
     * @return the initialized component instance
     */
    public Image getImage1() {
        if (image1 == null) {//GEN-END:|130-getter|0|130-preInit
            // write pre-init user code here
            try {//GEN-BEGIN:|130-getter|1|130-@java.io.IOException
                image1 = Image.createImage("/look.jpg");
            } catch (java.io.IOException e) {//GEN-END:|130-getter|1|130-@java.io.IOException
                e.printStackTrace();
            }//GEN-LINE:|130-getter|2|130-postInit
            // write post-init user code here
        }//GEN-BEGIN:|130-getter|3|
        return image1;
    }
    //</editor-fold>//GEN-END:|130-getter|3|

    /**
     * Returns a display instance.
     * @return the display instance.
     */
    public Display getDisplay() {
        return Display.getDisplay(this);
    }

    /**
     * Exits MIDlet.
     */
    public void exitMIDlet() {
        switchDisplayable(null, null);
        destroyApp(true);
        notifyDestroyed();
    }

    /**
     * Called when MIDlet is started.
     * Checks whether the MIDlet have been already started and initialize/starts or resumes the MIDlet.
     */
    public void startApp() {
        if (midletPaused) {
            resumeMIDlet();
        } else {
            initialize();
            startMIDlet();
        }
        midletPaused = false;
    }

    /**
     * Called when MIDlet is paused.
     */
    public void pauseApp() {
        midletPaused = true;
    }

    /**
     * Called to signal the MIDlet to terminate.
     * @param unconditional if true, then the MIDlet has to be unconditionally terminated and all resources has to be released.
     */
    public void destroyApp(boolean unconditional) {
    }

    public void showCamera() {
        try {

            /*System.out.println("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
            String[] contentTypes = Manager.getSupportedContentTypes(null);
            for (int i = 0; i < contentTypes.length; i++) {
            String[] protocols = Manager.getSupportedProtocols(contentTypes[i]);
            for (int j = 0; j < protocols.length; j++) {
            if(protocols[j].equals("device"))
            {StringItem si = new StringItem(contentTypes[i] + ": ", protocols[j]);
            getReportIncident().append(si);}
            }
            }*/


            player = Manager.createPlayer("capture://video");

            player.realize();
            videoControl = (VideoControl) player.getControl("VideoControl");
            VideoCanvas vc = new VideoCanvas(this, videoControl);
            vc.addCommand(capture);
            vc.addCommand(exit);
            getDisplay().setCurrent(vc);
            player.start();
            System.out.println("???¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
        } catch (IOException ioe) {
            ioe.printStackTrace();
            getReportIncident().append(ioe.getMessage());
        } catch (MediaException me) {
            me.printStackTrace();
            getReportIncident().append(me.getMessage());
        }
    }

    class Video extends Thread {

        ClientMIDlet midlet;

        public Video(ClientMIDlet midlet) {
            this.midlet = midlet;
        }

        public void run() {
            captureVideo();
        }

        public void captureVideo() {
            try {
                byte[] photo = videoControl.getSnapshot(null);
                Image image = Image.createImage(photo, 0, photo.length);
                reportIncident.append(image);
                midlet.getDisplay().setCurrent(reportIncident);
                player.close();
                player = null;
                videoControl = null;
            } catch (MediaException me) {
            }
        }
    };
}
