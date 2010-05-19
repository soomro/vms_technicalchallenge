/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package edu.vms;

import edu.vms.util.Request;
import edu.vms.util.VMSUtilities;
import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
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
    private Command backCommand;
    private Command sendCommand;
    private Command videoCommand;
    private Command itemCommand;
    private Command okCommand1;
    private Command loginCommand;
    private Command exitCommand1;
    private Command okCommand2;
    private Form main;
    private ChoiceGroup choiceGroup;
    private Spacer spacer;
    private ChoiceGroup choiceGroup2;
    private WaitScreen waitScreen;
    private Form request;
    private Form reportIncident;
    private TextField textField2;
    private TextField textField;
    private ChoiceGroup choiceGroup1;
    private Form reportProgress;
    private TextField textField4;
    private ChoiceGroup choiceGroup3;
    private Form viewRequest;
    private Form login;
    private TextField textField5;
    private TextField textField6;
    private StringItem stringItem;
    private Form alert;
    private Ticker ticker;
    private Image image1;
    //</editor-fold>//GEN-END:|fields|0|
    public VMSUtilities util;
    public boolean loggedIn = false;
    public boolean accepted = false;
    public Request reqInfo = new Request();
    public String[] alertIDs = {"", "", "", "", ""};
    public String[] alertN = {"", "", "", "", ""};
    public float lat;
    public float lon;
    private String username;
    private String password;
    public String errorMsg = "";
    public int alertIndex = 0;
    // create a Command
    public static Command SUCCESS_LOGIN = new Command("Successful login", 1, 1);

    /**
     * @Gilana Ramezani
     * The ClientMIDlet constructor
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

    //** starting MIDlet
    //<editor-fold defaultstate="collapsed" desc=" Generated Method: startMIDlet ">//GEN-BEGIN:|3-startMIDlet|0|3-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Started point.
     */
    public void startMIDlet() {//GEN-END:|3-startMIDlet|0|3-preAction
        // Show Wait Screen
        switchDisplayable(null, getLogin());//GEN-LINE:|3-startMIDlet|1|3-postAction

    }//GEN-BEGIN:|3-startMIDlet|2|
    //</editor-fold>//GEN-END:|3-startMIDlet|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: resumeMIDlet ">//GEN-BEGIN:|4-resumeMIDlet|0|4-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Resumed point.
     */
    public void resumeMIDlet() {//GEN-END:|4-resumeMIDlet|0|4-preAction
        // Show Wait Screen
        switchDisplayable(null, getWaitScreen());//GEN-LINE:|4-resumeMIDlet|1|4-postAction

    }//GEN-BEGIN:|4-resumeMIDlet|2|
    //</editor-fold>//GEN-END:|4-resumeMIDlet|2|

    // Defining switch dispay
    //<editor-fold defaultstate="collapsed" desc=" Generated Method: switchDisplayable ">//GEN-BEGIN:|5-switchDisplayable|0|5-preSwitch
    /**
     * Switches a current displayable in a display. The <code>display</code> instance is taken from <code>getDisplay</code> method. This method is used by all actions in the design for switching displayable.
     * @param alert the Alert which is temporarily set to the display; if <code>null</code>, then <code>nextDisplayable</code> is set immediately
     * @param nextDisplayable the Displayable to be set
     */
    public void switchDisplayable(Alert alert, Displayable nextDisplayable) {//GEN-END:|5-switchDisplayable|0|5-preSwitch

        // Create a new display and show Displayable value
        Display display = getDisplay();//GEN-BEGIN:|5-switchDisplayable|1|5-postSwitch
        if (alert == null) {
            display.setCurrent(nextDisplayable);
        } else {
            display.setCurrent(alert, nextDisplayable);
        }//GEN-END:|5-switchDisplayable|1|5-postSwitch
        // @Auther Gilana Ramezani
    }//GEN-BEGIN:|5-switchDisplayable|2|
    //</editor-fold>//GEN-END:|5-switchDisplayable|2|
    // Get action from User
    //<editor-fold defaultstate="collapsed" desc=" Generated Method: commandAction for Displayables ">//GEN-BEGIN:|7-commandAction|0|7-preCommandAction
    /**
     * Called by a system to indicated that a command has been invoked on a particular displayable.
     * @param command the Command that was invoked
     * @param displayable the Displayable where the command was invoked
     */
    public void commandAction(Command command, Displayable displayable) {//GEN-END:|7-commandAction|0|7-preCommandAction
        // Select Alert command
        if (displayable == alert) {//GEN-BEGIN:|7-commandAction|1|163-preAction
            if (command == okCommand2) {//GEN-END:|7-commandAction|1|163-preAction
                // write pre-action user code here
                for (int i = alertIndex; i < 4; i++) {
                    alertIDs[i] = alertIDs[i + 1];
                    alertN[i] = alertN[i + 1];
                    getChoiceGroup2().set(i, alertN[i + 1], null);
                }
                alertIDs[3] = alertIDs[4];
                alertN[3] = alertN[4];
                getChoiceGroup2().set(4, alertN[4], null);
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|2|163-postAction
                // write post-action user code here
            }//GEN-BEGIN:|7-commandAction|3|148-preAction
        } else if (displayable == login) {
            if (command == exitCommand1) {//GEN-END:|7-commandAction|3|148-preAction
                // Select exitcommand
                exitMIDlet();//GEN-LINE:|7-commandAction|4|148-postAction
                // Select login command
            } else if (command == loginCommand) {//GEN-LINE:|7-commandAction|5|146-preAction
                // Show Wait Screen
                switchDisplayable(null, getWaitScreen());//GEN-LINE:|7-commandAction|6|146-postAction
                //Get Username and password for Login
                username = ((TextField) login.get(1)).getString().trim();
                password = ((TextField) login.get(2)).getString().trim();
                // Verifying Username and Password
                util.checkUsernameAndPassword();

                // Select Exit button in main page
            }//GEN-BEGIN:|7-commandAction|7|19-preAction
        } else if (displayable == main) {
            if (command == exitCommand) {//GEN-END:|7-commandAction|7|19-preAction
                // Exit mobile application
                exitMIDlet();//GEN-LINE:|7-commandAction|8|19-postAction
                // Select logout Command
            } else if (command == logoutCommand) {//GEN-LINE:|7-commandAction|9|109-preAction

                switchDisplayable(null, getLogin());//GEN-LINE:|7-commandAction|10|109-postAction
                util.logout();

            } else if (command == progressCommand) {//GEN-LINE:|7-commandAction|11|105-preAction
                // Show Report Progress page
                if (!reqInfo.ID.equals("")) {
                    switchDisplayable(null, getReportProgress());//GEN-LINE:|7-commandAction|12|105-postAction
                }// Show Report page
            } else if (command == reportCommand) {//GEN-LINE:|7-commandAction|13|88-preAction
                // Show Report Incident page
                switchDisplayable(null, getReportIncident());//GEN-LINE:|7-commandAction|14|88-postAction
                // Select Cancel and navigate to main page
            }//GEN-BEGIN:|7-commandAction|15|94-preAction
        } else if (displayable == reportIncident) {
            if (command == cancelCommand) {//GEN-END:|7-commandAction|15|94-preAction

                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|16|94-postAction
                // Select Send Command
            } else if (command == sendCommand) {//GEN-LINE:|7-commandAction|17|117-preAction
                if (util.checkInRepor()) {
                    util.sendReport();
                }
//GEN-LINE:|7-commandAction|18|117-postAction
                // Select Cancel and navigate to main page
            }//GEN-BEGIN:|7-commandAction|19|97-preAction
        } else if (displayable == reportProgress) {
            if (command == cancelCommand1) {//GEN-END:|7-commandAction|19|97-preAction

                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|20|97-postAction

                // Select Send Progress Command
            } else if (command == sendProgressCommand) {//GEN-LINE:|7-commandAction|21|103-preAction
//GEN-LINE:|7-commandAction|22|103-postAction
                if (util.checkPrRepor()) {
                    util.sendProgress();
                }
                // Show Request page and select accept or  reject command
            }//GEN-BEGIN:|7-commandAction|23|78-preAction
        } else if (displayable == request) {
            if (command == acceptCommand) {//GEN-END:|7-commandAction|23|78-preAction
                // Process request and answer
                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|24|78-postAction
                util.acceptRequest();

            } else if (command == rejectCommand) {//GEN-LINE:|7-commandAction|25|80-preAction

                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|26|80-postAction
                util.removeRequest();

            }//GEN-BEGIN:|7-commandAction|27|120-preAction
        } else if (displayable == viewRequest) {
            if (command == backCommand) {//GEN-END:|7-commandAction|27|120-preAction

                switchDisplayable(null, getMain());//GEN-LINE:|7-commandAction|28|120-postAction

            }//GEN-BEGIN:|7-commandAction|29|50-preAction
        } else if (displayable == waitScreen) {
            if (command == WaitScreen.FAILURE_COMMAND) {//GEN-END:|7-commandAction|29|50-preAction
                // write pre-action user code here
                switchDisplayable(null, getLogin());
                switchDisplayable(null, getLogin());//GEN-LINE:|7-commandAction|30|50-postAction
                // write post-action user code here
            } else if (command == WaitScreen.SUCCESS_COMMAND) {//GEN-LINE:|7-commandAction|31|49-preAction
                // write pre-action user code here
                if (loggedIn) {
                    switchDisplayable(null, getMain());
                } else {
                    switchDisplayable(null, getLogin());
                }
//GEN-LINE:|7-commandAction|32|49-postAction
                // write post-action user code here
            } else if (command == ClientMIDlet.SUCCESS_LOGIN) {
                switchDisplayable(null, getMain());
                util.checkPeriodically();
            }//GEN-BEGIN:|7-commandAction|33|7-postCommandAction
        }//GEN-END:|7-commandAction|33|7-postCommandAction
        // write post-action user code here
    }//GEN-BEGIN:|7-commandAction|34|
    //</editor-fold>//GEN-END:|7-commandAction|34|

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
                    util.getRequestInfo();

                }// write post-action user code here
            }//GEN-BEGIN:|17-itemCommandAction|3|139-preAction
        } else if (item == choiceGroup2) {
            if (command == okCommand) {//GEN-END:|17-itemCommandAction|3|139-preAction
                // write pre-action user code here
                int selectedIndex = choiceGroup2.getSelectedIndex();
                System.out.println("selectedIndex " + selectedIndex);
                System.out.println(alertIDs[selectedIndex]);
                if (!alertIDs[selectedIndex].equals("")) {
                    alertIndex = selectedIndex;
                    util.getAlert();
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
            reportCommand = new Command("Report incident", "Report incident", Command.OK, 1);//GEN-LINE:|87-getter|1|87-postInit
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
            sendProgressCommand = new Command("Send", "Send", Command.OK, 0);//GEN-LINE:|102-getter|1|102-postInit
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
            progressCommand = new Command(" Report progress ", " Report progress ", Command.OK, 1);//GEN-LINE:|104-getter|1|104-postInit
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
            reportIncident = new Form("Report Incident", new Item[] { getTextField(), getTextField2(), getChoiceGroup1() });//GEN-BEGIN:|85-getter|1|85-postInit
            reportIncident.setTicker(getTicker());
            reportIncident.addCommand(getCancelCommand());
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
            reportProgress = new Form("Progress report", new Item[] { getTextField4(), getChoiceGroup3() });//GEN-BEGIN:|86-getter|1|86-postInit
            reportProgress.setTicker(getTicker());
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
            textField = new TextField("Location", null, 100, TextField.ANY);//GEN-LINE:|122-getter|1|122-postInit
            // write post-init user code here
        }//GEN-BEGIN:|122-getter|2|
        return textField;
    }
    //</editor-fold>//GEN-END:|122-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField2 ">//GEN-BEGIN:|125-getter|0|125-preInit
    /**
     * Returns an initiliazed instance of textField2 component.
     * @return the initialized component instance
     */
    public TextField getTextField2() {
        if (textField2 == null) {//GEN-END:|125-getter|0|125-preInit
            // write pre-init user code here
            textField2 = new TextField("Message to the manager", null, 300, TextField.ANY);//GEN-LINE:|125-getter|1|125-postInit
            // write post-init user code here
        }//GEN-BEGIN:|125-getter|2|
        return textField2;
    }
    //</editor-fold>//GEN-END:|125-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField4 ">//GEN-BEGIN:|127-getter|0|127-preInit
    /**
     * Returns an initiliazed instance of textField4 component.
     * @return the initialized component instance
     */
    public TextField getTextField4() {
        if (textField4 == null) {//GEN-END:|127-getter|0|127-preInit
            // write pre-init user code here
            textField4 = new TextField("Message", null, 300, TextField.ANY);//GEN-LINE:|127-getter|1|127-postInit
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

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: login ">//GEN-BEGIN:|142-getter|0|142-preInit
    /**
     * Returns an initiliazed instance of login component.
     * @return the initialized component instance
     */
    public Form getLogin() {
        if (login == null) {//GEN-END:|142-getter|0|142-preInit
            // write pre-init user code here
            login = new Form("Login", new Item[] { getStringItem(), getTextField5(), getTextField6() });//GEN-BEGIN:|142-getter|1|142-postInit
            login.setTicker(getTicker());
            login.addCommand(getLoginCommand());
            login.addCommand(getExitCommand1());
            login.setCommandListener(this);//GEN-END:|142-getter|1|142-postInit
            // write post-init user code here
        }//GEN-BEGIN:|142-getter|2|
        return login;
    }
    //</editor-fold>//GEN-END:|142-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: itemCommand ">//GEN-BEGIN:|143-getter|0|143-preInit
    /**
     * Returns an initiliazed instance of itemCommand component.
     * @return the initialized component instance
     */
    public Command getItemCommand() {
        if (itemCommand == null) {//GEN-END:|143-getter|0|143-preInit
            // write pre-init user code here
            itemCommand = new Command("Item", Command.ITEM, 0);//GEN-LINE:|143-getter|1|143-postInit
            // write post-init user code here
        }//GEN-BEGIN:|143-getter|2|
        return itemCommand;
    }
    //</editor-fold>//GEN-END:|143-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: loginCommand ">//GEN-BEGIN:|145-getter|0|145-preInit
    /**
     * Returns an initiliazed instance of loginCommand component.
     * @return the initialized component instance
     */
    public Command getLoginCommand() {
        if (loginCommand == null) {//GEN-END:|145-getter|0|145-preInit
            // write pre-init user code here
            loginCommand = new Command("Login", "Login", Command.OK, 0);//GEN-LINE:|145-getter|1|145-postInit
            // write post-init user code here
        }//GEN-BEGIN:|145-getter|2|
        return loginCommand;
    }
    //</editor-fold>//GEN-END:|145-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: exitCommand1 ">//GEN-BEGIN:|147-getter|0|147-preInit
    /**
     * Returns an initiliazed instance of exitCommand1 component.
     * @return the initialized component instance
     */
    public Command getExitCommand1() {
        if (exitCommand1 == null) {//GEN-END:|147-getter|0|147-preInit
            // write pre-init user code here
            exitCommand1 = new Command("Exit", Command.EXIT, 0);//GEN-LINE:|147-getter|1|147-postInit
            // write post-init user code here
        }//GEN-BEGIN:|147-getter|2|
        return exitCommand1;
    }
    //</editor-fold>//GEN-END:|147-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField5 ">//GEN-BEGIN:|155-getter|0|155-preInit
    /**
     * Returns an initiliazed instance of textField5 component.
     * @return the initialized component instance
     */
    public TextField getTextField5() {
        if (textField5 == null) {//GEN-END:|155-getter|0|155-preInit
            // write pre-init user code here
            textField5 = new TextField("Username", "", 50, TextField.ANY);//GEN-LINE:|155-getter|1|155-postInit
            // write post-init user code here
        }//GEN-BEGIN:|155-getter|2|
        return textField5;
    }
    //</editor-fold>//GEN-END:|155-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: textField6 ">//GEN-BEGIN:|156-getter|0|156-preInit
    /**
     * Returns an initiliazed instance of textField6 component.
     * @return the initialized component instance
     */
    public TextField getTextField6() {
        if (textField6 == null) {//GEN-END:|156-getter|0|156-preInit
            // write pre-init user code here
            textField6 = new TextField("Password", "", 50, TextField.ANY | TextField.PASSWORD);//GEN-LINE:|156-getter|1|156-postInit
            // write post-init user code here
        }//GEN-BEGIN:|156-getter|2|
        return textField6;
    }
    //</editor-fold>//GEN-END:|156-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: stringItem ">//GEN-BEGIN:|158-getter|0|158-preInit
    /**
     * Returns an initiliazed instance of stringItem component.
     * @return the initialized component instance
     */
    public StringItem getStringItem() {
        if (stringItem == null) {//GEN-END:|158-getter|0|158-preInit
            // write pre-init user code here
            stringItem = new StringItem("Volunteer\'s Management System", "", Item.PLAIN);//GEN-BEGIN:|158-getter|1|158-postInit
            stringItem.setLayout(ImageItem.LAYOUT_CENTER | Item.LAYOUT_TOP | Item.LAYOUT_VCENTER | ImageItem.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);//GEN-END:|158-getter|1|158-postInit
            // write post-init user code here
        }//GEN-BEGIN:|158-getter|2|
        return stringItem;
    }
    //</editor-fold>//GEN-END:|158-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: alert ">//GEN-BEGIN:|161-getter|0|161-preInit
    /**
     * Returns an initiliazed instance of alert component.
     * @return the initialized component instance
     */
    public Form getAlert() {
        if (alert == null) {//GEN-END:|161-getter|0|161-preInit
            // write pre-init user code here
            alert = new Form("Alert");//GEN-BEGIN:|161-getter|1|161-postInit
            alert.addCommand(getOkCommand2());
            alert.setCommandListener(this);//GEN-END:|161-getter|1|161-postInit
            // write post-init user code here
        }//GEN-BEGIN:|161-getter|2|
        return alert;
    }
    //</editor-fold>//GEN-END:|161-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: okCommand2 ">//GEN-BEGIN:|162-getter|0|162-preInit
    /**
     * Returns an initiliazed instance of okCommand2 component.
     * @return the initialized component instance
     */
    public Command getOkCommand2() {
        if (okCommand2 == null) {//GEN-END:|162-getter|0|162-preInit
            // write pre-init user code here
            okCommand2 = new Command("Ok", "OK", Command.OK, 0);//GEN-LINE:|162-getter|1|162-postInit
            // write post-init user code here
        }//GEN-BEGIN:|162-getter|2|
        return okCommand2;
    }
    //</editor-fold>//GEN-END:|162-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: choiceGroup1 ">//GEN-BEGIN:|165-getter|0|165-preInit
    /**
     * Returns an initiliazed instance of choiceGroup1 component.
     * @return the initialized component instance
     */
    public ChoiceGroup getChoiceGroup1() {
        if (choiceGroup1 == null) {//GEN-END:|165-getter|0|165-preInit
            // write pre-init user code here
            choiceGroup1 = new ChoiceGroup("Incident type", Choice.EXCLUSIVE);//GEN-BEGIN:|165-getter|1|165-postInit
            choiceGroup1.append("Fire", null);
            choiceGroup1.append("Collapsed Building ", null);
            choiceGroup1.append("Bomb", null);
            choiceGroup1.append("Accident", null);
            choiceGroup1.setFitPolicy(Choice.TEXT_WRAP_DEFAULT);
            choiceGroup1.setSelectedFlags(new boolean[] { false, false, false, false });//GEN-END:|165-getter|1|165-postInit
            // write post-init user code here
        }//GEN-BEGIN:|165-getter|2|
        return choiceGroup1;
    }
    //</editor-fold>//GEN-END:|165-getter|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Getter: choiceGroup3 ">//GEN-BEGIN:|170-getter|0|170-preInit
    /**
     * Returns an initiliazed instance of choiceGroup3 component.
     * @return the initialized component instance
     */
    public ChoiceGroup getChoiceGroup3() {
        if (choiceGroup3 == null) {//GEN-END:|170-getter|0|170-preInit
            // write pre-init user code here
            choiceGroup3 = new ChoiceGroup("Status", Choice.EXCLUSIVE);//GEN-BEGIN:|170-getter|1|170-postInit
            choiceGroup3.append("Created", null);
            choiceGroup3.append("Resource Gathering", null);
            choiceGroup3.append("Working", null);
            choiceGroup3.append("Completed", null);
            choiceGroup3.setSelectedFlags(new boolean[] { false, false, false, false });//GEN-END:|170-getter|1|170-postInit
            // write post-init user code here
        }//GEN-BEGIN:|170-getter|2|
        return choiceGroup3;
    }
    //</editor-fold>//GEN-END:|170-getter|2|

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

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }
}
