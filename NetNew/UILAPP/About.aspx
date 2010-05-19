<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    Inherits="About" CodeBehind="About.aspx.cs" %>
<%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <table class="tblFrontPage" style="width:100%; border:1">
        <tr>
        <td colspan="2">
        

         <span class="spInfoTitle" style="horizontal-align:center;"><br />Apollo Group proudly presents</span></td>
        </tr><tr>
            <td style="width:60%;">
               
                    <img src="Images/apollo.jpg" />
                    <br />
                   
                    
            </td>
            <td style="width:40%;">
             <ul>
                    <li>Abdollah Tabareh</li>
                    <li>Gilana Ramazani</li>
                    <li>Abdullah Arslan</li>
                    <li>Waseem Soomro</li>
                    <li>Shobha BC</li>
                    <li>Mustafa Al-Zubaidi</li>
                    <li>Tigran Harutyunyan</li>
                    </ul>
            </td>
        </tr>
    </table>
</asp:Content>
