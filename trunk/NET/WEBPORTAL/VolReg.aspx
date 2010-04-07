<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="true" CodeFile="VolReg.aspx.cs" Inherits="VolReg" %>
<%@ MasterType TypeName="PageMaster" %>
<%@ Register src="UC/ucEnumSelector.ascx" tagname="ucEnumSelector" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="float: left;">
        <table class="tblForm">
            <tr>
                <td class="label">
                    First Name:</td>
                <td class="value">
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Last Name:</td>
                <td class="value">
        <asp:TextBox ID="txtLastName" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Birthdate:<br />
                    (yyyy.mm.dd)</td>
                <td class="value">
        <asp:TextBox ID="txtBirthDate" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Gender:</td>
                <td class="value">
                    <uc1:ucEnumSelector ID="ucEnumSelectorGender" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="label">
                    Phone:</td>
                <td class="value">
        <asp:TextBox ID="txtPhone" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Height:</td>
                <td class="value">
        <asp:TextBox ID="txtHeight" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Weight:</td>
                <td class="value">
        <asp:TextBox ID="txtWeight" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Education:</td>
                <td class="value">
        <asp:TextBox ID="txtEducation" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Special training:</td>
                <td class="value">
        <asp:TextBox ID="txtSpecialTraining" runat="server" CssClass="tx" Rows="4" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Occupation:</td>
                <td class="value">
        <asp:TextBox ID="txtOccupation" runat="server" CssClass="tx" Rows="4" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Country:</td>
                <td class="value">
        <asp:TextBox ID="txtCountry" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    City:</td>
                <td class="value">
        <asp:TextBox ID="txtCity" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Street:</td>
                <td class="value">
        <asp:TextBox ID="txtStreet" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    House No.</td>
                <td class="value">
        <asp:TextBox ID="txtHouseNo" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Flat No.:</td>
                <td class="value">
        <asp:TextBox ID="txtFlatNo" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Postal code:</td>
                <td class="value">
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
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
                <td>
                    &nbsp;</td>
                <td>
        <asp:Button ID="btnRegister" runat="server" Text="Register" onclick="btnRegister_Click" />
        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" style="height: 26px" 
                         />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

