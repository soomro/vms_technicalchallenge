<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CrisisBoard.aspx.cs" Inherits="CrisisBoard" %>

<%@ MasterType TypeName="SiteMaster" %>

<%@ Register Src="UControls/UCCreateCrisisMap.ascx" TagName="UCCreateCrisisMap" TagPrefix="uc1" %>
<%@ Register Src="UControls/UCMap.ascx" TagName="UCMap" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" style="height: 400px">
        <tr>
            <td width="300px">
                 
                <asp:Accordion ID="Accordion1" runat="server"  Height="400px" AutoSize="Fill"
                    ContentCssClass="accordionContent" HeaderCssClass="accordionHeader"  >
                    <Panes>
                        <asp:AccordionPane runat="server" ID="pn1">
                            <Header>
                                Create New Incident</Header>
                            <Content>
                                here u can create new incidents</Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane runat="server" ID="pn2">
                            <Header>
                                Incident Reports</Header>
                            <Content>
                                here is list of incident reports</Content>
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
