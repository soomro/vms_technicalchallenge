<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Login" Codebehind="Login.aspx.cs" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">&nbsp;
 <table width="98%">
        <tr>
            <td style="width: 20%; vertical-align:top;" id="login" >
                
                
                <table class="tblForm tblFrontPage">
                <tr>
                <td colspan="2"><span class="spInfoTitle">Login</span><br /></td>
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
                <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem>Volunteer</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                </asp:DropDownList>
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
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                    Text="Login" CssClass="buttons" />
                &nbsp;
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" CssClass="buttons" />
            </td>
        </tr>
    </table>



            </td>
            <td style="width: 80%;"> 
            <table  class="tblFrontPage">
            <tr>
                <td colspan="2">
                <span class="spInfoTitle">General overview</span>
                <p>
                    Volunteer’s Management System. Magnificent innovative IT solution to attack the
                    crisis more effectively than ever before. VMS is combined effort from Volunteers
                    and help organizations to serve the crisis affected people on time.</p>
               
               </td></tr>
                    <tr>
                        <td>
                            <span class="spInfoTitle">Volunteers</span>
                            <p>
                                Want to help the crisis affected, than what are you waiting for? Get registered
                                to the Volunteer’s Management System. Help the society by contributing your few
                                hrs and affordable things.<br /><br />
                                <a href="VMSClient.jar" class="download" >Download mobile VMS application</a>
                                &nbsp;</p>
                        </td>
                        <td>
                            <span class="spInfoTitle">Help organization</span>
                            <p>
                                Human ethics are most valued here, 100% services oriented organization aims to resolve
                                the Crisis with the help of normal citizens. Like you!!! Maintains the coordination
                                between volunteers and the crisis affected people to resolve any crisis.
                            </p>
                        </td>
                    </tr>
                </table>
              
            </td>
        </tr>
    </table>

    
</asp:Content>

