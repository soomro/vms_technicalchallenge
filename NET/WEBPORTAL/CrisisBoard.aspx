<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="true" CodeFile="CrisisBoard.aspx.cs" Inherits="CrisisBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <br />
    <a href="Crisispage.aspx?action=Create">Create Crisis</a><br />
    <a href="Crisispage.aspx?action=Edit">Edit Crisis</a><br />
</asp:Content>

