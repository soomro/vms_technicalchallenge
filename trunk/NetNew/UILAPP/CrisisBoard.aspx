<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="CrisisBoard" Codebehind="CrisisBoard.aspx.cs" %>

<%@ MasterType TypeName="SiteMaster" %>

<%@ Register Src="UControls/UCCreateCrisisMap.ascx" TagName="UCCreateCrisisMap" TagPrefix="uc1" %>
<%@ Register Src="UControls/UCMap.ascx" TagName="UCMap" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <link href="Styles/Verticalmenu.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" style="height: 400px">
        <tr>
            <td width="300px" valign="top">
                 
                <asp:Accordion ID="Accordion1" runat="server"  Height="400px" AutoSize="Fill"
                    ContentCssClass="accordionContent" HeaderCssClass="accordionHeader"  >
                    <Panes>
                        <asp:AccordionPane runat="server" ID="pn1">
                            <Header>
                                Crisis</Header>
                            <Content>
                            <div class="markermenu">
                            <ul>
                            <li><a  href="Crisis.aspx">Define new crisis</a></li>    
                            <li><a  runat="server"  id="hlEditCrisis" href="Crisis.aspx?Action=Edit">Edit crisis</a></li> 
                              <li>  <a  href="CrisisList.aspx">List all crises</a></li>  </ul></div>
                                </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="pn2">
                            <Header>
                                Incident</Header>
                            <Content>
                               <div class="markermenu">
                            <ul>
                            <li><a  runat="server"  id="hlNewIncident" href="Incident.aspx">Create new incident</a></li>
                              <li> <a runat="server" href="IncidentList.aspx" ID="hlIncidentlist">List all incidents</a></li></ul></div>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="pn3">
                            <Header>
                                Reports</Header>
                            <Content>
                               <div class="markermenu">
                            <ul>
                            <li> <a href="IncidentReports.aspx">View new incident reports</a></li></ul></div>
                                </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="pn4">
                            <Header>
                                Alert</Header>
                            <Content>
                                   <div class="markermenu">
                            <ul>
                            <li> <a href="Alert.aspx">Send alert</a></li>
                                <li>   <a href="AlertList.aspx">List all alerts</a></li></ul></div>
                                 </Content>
                        </asp:AccordionPane>

                         <asp:AccordionPane runat="server" ID="pn5">
                            <Header>
                                Settings</Header>
                            <Content>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td><asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="cbxShowClosed_CheckedChanged" ID="cbxShowClosed" Text="Show closed incidents"/>
                                        </td>
                                    </tr>
                                </table>
                                <div class="markermenu">
                            <ul>
                            <li> <asp:Hyperlink runat="server" ID="hlProfile"  >Profile Settings</asp:Hyperlink></li>
                               </ul></div>
                                 </Content>
                        </asp:AccordionPane>
                       
                    </Panes>
                    
                </asp:Accordion>
            </td>
            <td> 
                <uc2:UCMap ID="UCMap1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
