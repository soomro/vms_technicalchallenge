<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Alert.aspx.cs" Inherits="Alert" %>

<%@ Register src="UControls/UCSearchVolunteer.ascx" tagname="UCSearchVolunteer" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" ID="pnlDivForm">
        <table class="tblForm" width="100%">
            <tr>
                <td class="formField" align="left" width="5%">
                    Alert Message:</td>
                <td class="value" rowspan="5" align="right" >
                    <uc1:UCSearchVolunteer ID="ucSearchVolunteer" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formField" align="left" width="5%" valign="top">
                    <asp:TextBox ID="txtMessage" runat="server" CssClass="tx" 
                        TextMode="MultiLine" Height="146px" Width="374px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formField" width="5%" align="left">
                    <asp:Button ID="btnSend" runat="server" CssClass="buttons" 
                        onclick="btnSend_Click" Text="Send" ValidationGroup="1" />
                </td>
            </tr>
            <tr>
                <td class="formField" align="left" width="5%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField" width="5%">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
