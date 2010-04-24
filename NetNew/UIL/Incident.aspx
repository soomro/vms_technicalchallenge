<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Incident.aspx.cs"
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
            <td width="300px" valign="top">
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
                            Short Description
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txShortDesc" Height="40px" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Need List
                        </td>
                        <td align="right">
                           <asp:GridView ID="gvNeedList" runat="server" AutoGenerateColumns="False" 
                                BorderColor="Red" BorderWidth="1px" Width="100%" 
                                EmptyDataText="No need item is defined" 
                                onrowdatabound="gvNeedList_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>                                        
                                            <asp:TextBox ID="txItemType" runat="server" Width="50px" AutoComplete="Off"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txItemType_AutoCompleteExtender" runat="server" 
                                                CompletionInterval="400" DelimiterCharacters="" EnableCaching="False" 
                                                Enabled="True" FirstRowSelected="True" MinimumPrefixLength="2" 
                                                ServiceMethod="GetCompletionList" ServicePath="" TargetControlID="txItemType" 
                                                UseContextKey="True">
                                            </asp:AutoCompleteExtender>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <uc2:ucEnumSelector ID="ucUnit" runat="server" 
                                                SelectionType="DropDownList" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txAmount" runat="server" MaxLength="5" Width="40px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txAmount_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" TargetControlID="txAmount" 
                                                ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Col.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txCollected" runat="server" MaxLength="5" Width="40px"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txCollected_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" TargetControlID="txCollected" 
                                                ValidChars="0987654321.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtRemove" runat="server" AlternateText="Remove" 
                                                ImageUrl="~/Images/remove.jpg" oncommand="ibtRemove_Command" ToolTip="Remove" 
                                                Width="15px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Bold="False" Font-Size="9pt" Font-Underline="True" />
                            </asp:GridView>
                            <asp:Button ID="btAddNew" runat="server" Text="Add New" 
                                onclick="btAddNew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Explanation</td>
                        <td valign="top">
                            <asp:TextBox runat="server" ID="txExplanation" Height="61px" Width="100%" 
                                Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Short Address</td>
                        <td valign="top">
                            <asp:TextBox ID="txShortAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
                            <asp:Button ID="btSave" runat="server" Text="Save" onclick="btSave_Click" />
                        </td>
                    </tr>
        </table> </td>
        <td>
            <uc1:UCIncidentMap ID="UCIncidentMap1" runat="server" Width="100%" Heigth="400px" />
        </td>
        </tr>
    </table>
</asp:Content>
