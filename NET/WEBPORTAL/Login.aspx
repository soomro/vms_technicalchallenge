<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ MasterType TypeName="PageMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left;">
        <table class="tblForm">
            <tr>
                <td class="label">
                    Username:</td>
                <td class="value">
        <asp:TextBox ID="txtUserName" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Password:</td>
                <td class="value">
        <asp:TextBox ID="txtPassword" runat="server" CssClass="tx" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
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
        <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" />
        &nbsp;<asp:Button ID="btnRegister" runat="server" Text="Register" 
                        onclick="btnRegister_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
