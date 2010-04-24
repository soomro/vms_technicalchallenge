﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Incident.aspx.cs"
    Inherits="Incident" %>

<%@ MasterType TypeName="SiteMaster" %>
<%@ Register Src="UControls/UCIncidentMap.ascx" TagName="UCIncidentMap" TagPrefix="uc1" %>
<%@ Register Src="UControls/ucEnumSelector.ascx" TagName="ucEnumSelector" TagPrefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" border="0" style="border: 1px dotted #FF0000"   >
        <tr>
            <td width="300px">
                <table border="0" style="border: 2px dotted #0000FF" width="100%"  >
                    <tr>
                        <td width="30px">
                            Incident Type
                        </td>
                        <td>
                            <uc2:ucEnumSelector ID="ucIncidentType" runat="server" SelectionType="DropDownList" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Severity
                        </td>
                        <td>
                            <uc2:ucEnumSelector ID="ucSeverity" runat="server" 
                                SelectionType="DropDownList"    />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Information
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txInfo" Height="40px" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Need List
                        </td>
                        <td>
                           <asp:GridView ID="gvNeedList" runat="server" AutoGenerateColumns="False" 
                                BorderColor="Red" BorderWidth="1px" Width="100%" 
                                EmptyDataText="No need item is defined" 
                                onrowdatabound="gvNeedList_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                        
                                            <uc2:ucEnumSelector ID="ucType" runat="server" SelectionType="DropDownList" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <uc2:ucEnumSelector ID="ucUnit" runat="server" 
                                                SelectionType="DropDownList" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txAmount" runat="server" MaxLength="5" Width="40px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txAmount_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" TargetControlID="txAmount" 
                                                ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Col.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txCollected" runat="server" MaxLength="5" Width="40px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txCollected_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" TargetControlID="txCollected" 
                                                ValidChars="0987654321.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Bold="False" Font-Size="9pt" Font-Underline="True" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btAddNew" runat="server" Text="Add New" 
                                onclick="btAddNew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                        </td>
                    </tr>
        </table> </td>
        <td>
            <uc1:UCIncidentMap ID="UCIncidentMap1" runat="server" Width="100%" Heigth="400px" />
        </td>
        </tr>
    </table>
</asp:Content>
