﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Crisis.aspx.cs" Inherits="Crisis" %>

<%@ MasterType TypeName="SiteMaster" %>
<%@ Register Src="UControls/ucEnumSelector.ascx" TagName="ucEnumSelector" TagPrefix="uc1" %>
<%@ Register Src="UControls/UCCreateCrisisMap.ascx" TagName="UCCreateCrisisMap" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="float: left;">
        <table class="tblForm">
            <tr>
                <td class="label">
                    Crisis Name
                </td>
                <td class="value">
                    <asp:TextBox ID="txtCrisisName" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Explanation
                </td>
                <td class="value">
                    <asp:TextBox ID="txtExplanation" runat="server" CssClass="tx" TextMode="MultiLine"
                        Rows="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Crisis Type
                </td>
                <td class="value">
                    <uc1:ucEnumSelector ID="ucEnumSelector1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="label">
                    Radious(km)
                </td>
                <td class="value">
                    <asp:DropDownList ID="ddlRadious" runat="server" OnSelectedIndexChanged="ddlRadious_SelectedIndexChanged"
                        AutoPostBack="True" CssClass="tx">
                        <asp:ListItem Value="10">40</asp:ListItem>
                        <asp:ListItem Value="20">80</asp:ListItem>
                        <asp:ListItem Value="30">120</asp:ListItem>
                        <asp:ListItem Value="40">160</asp:ListItem>
                        <asp:ListItem Value="50">200</asp:ListItem>
                        <asp:ListItem Value="60">240</asp:ListItem>
                        <asp:ListItem Value="70">280</asp:ListItem>
                        <asp:ListItem Value="80">320</asp:ListItem>
                        <asp:ListItem Value="90">360</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="label">
                    &nbsp;
                </td>
                <td class="value" align="right">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons"/>
                    &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btSave_Click" 
                        Text="Save" CssClass="buttons" />
                </td>
            </tr>
        </table>
    </div>
    <div style="float: left">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc2:UCCreateCrisisMap ID="UCCreateCrisisMap1" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlRadious" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
