<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 10px;
            font-family: sans-serif;
            color: #800000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="tblForm">
        <tr>
            <td class="style1">
                Username:</td>
            <td class="value">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Password:</td>
            <td class="value">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="tx" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="value">
                <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem>Volunteer</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                    Text="Login" />
                &nbsp;
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" />
            </td>
        </tr>
    </table>
</asp:Content>

