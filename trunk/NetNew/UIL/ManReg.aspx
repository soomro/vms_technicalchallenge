﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManReg.aspx.cs" Inherits="ManReg" %>


<%@ Register src="UControls/ucEnumSelector.ascx" tagname="ucEnumSelector" tagprefix="uc1" %>


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
                First Name:</td>
            <td class="value">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Last Name:</td>
            <td class="value">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Birthdate:<br />
                (yyyy.mm.dd)</td>
            <td class="value">
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Gender:</td>
            <td class="value">
                <uc1:ucEnumSelector ID="ucEnumSelectorGender" runat="server"></uc1:ucEnumSelector>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="value">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Expertise in<br />
                crisi handling:</td>
            <td class="value">
                <asp:TextBox ID="txtExpertiseCrisisTypes" runat="server" CssClass="tx" Rows="4" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Country:</td>
            <td class="value">
                <asp:TextBox ID="txtCountry" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                City:</td>
            <td class="value">
                <asp:TextBox ID="txtCity" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Street:</td>
            <td class="value">
                <asp:TextBox ID="txtStreet" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                House No.</td>
            <td class="value">
                <asp:TextBox ID="txtHouseNo" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Flat No.:</td>
            <td class="value" style="margin-left: 40px">
                <asp:TextBox ID="txtFlatNo" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Postal code:</td>
            <td class="value">
                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
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
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                    style="height: 26px" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>

