<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<%@ MasterType TypeName="SiteMaster" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    This page is the default page of the system but will serve for test purposes 
    now.<br />
    crisis id:
    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
        ontextchanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="edit" />
&nbsp;

    <br />
    
&nbsp;<asp:Button ID="Button2" runat="server" Text="Button" 
        onclick="Button2_Click" />


    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />


</asp:Content>
