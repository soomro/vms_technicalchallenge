<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateRequest.aspx.cs" Inherits="CreateRequest" %>
<%@ Register Src="UControls/UCIncidentMap.ascx" TagName="UCIncidentMap" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UControls/ucRequestMap.ascx" TagName="ucRequestMap" TagPrefix="uc2" %>
<%@ MasterType TypeName="SiteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

  
                    <table border="0" cellpadding="0" cellspacing="0" width="99%">
                        <tr>
                            <td style="width: 200px;" valign="top">
                                <p>
                                    Request name<br />
                                    <asp:TextBox ID="txRequestName" runat="server" Width="90%"></asp:TextBox>
                                    <br />
                                </p>
                                <p>
                                    &nbsp;</p>
                                <p>
                                    Request message<br />
                                    <asp:TextBox runat="server" ID="txMessage" TextMode="MultiLine" Width="90%" />
                                    <br />
                                </p>
                                <p>
                                    &nbsp;</p>
                                Need items to be requested
                                <div>
                                    <asp:CheckBoxList runat="server" ID="cblNeedlist">
                                    </asp:CheckBoxList>  
                                </div>
                                    <br />
                                    <div runat="server" id="dvStatus">
                                    <asp:Label Text="Staus" runat="server" ID="lbStatus" /><br />
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" id="rblStatus"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Text="Active" />
                                        <asp:ListItem Text="Suspended" />
                                    </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <asp:Button ID="btCancel" runat="server" Text="Cancel" 
                                        onclick="btCancel_Click" />
               
        

&nbsp;
                    <asp:Button ID="btSaveRequest" runat="server" Text="Save" OnClick="btSaveRequest_Click" />
                              
                            </td>
                            <td valign="top">
                                <uc2:ucRequestMap ID="ucRequestMap1" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;
               
        

</asp:Content>

