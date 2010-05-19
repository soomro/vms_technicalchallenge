<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    Inherits="_Default" CodeBehind="Default.aspx.cs" %>

<%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="98%">
        <tr>
            <td style="width: 20%;">
                Login Box
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
