<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ResourceGathering.aspx.cs" Inherits="ResourceGathering" %>

<%@ MasterType TypeName="SiteMaster" %>
<%@ Register Src="UControls/UCIncidentMap.ascx" TagName="UCIncidentMap" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="UControls/ucRequestMap.ascx" TagName="ucRequestMap" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Panel runat="server" ID="pnRequestList" GroupingText="Request List">
                 
                    <asp:GridView runat="server" ID="gvReqList" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="This incident has no request"
                        ShowHeader="False" Width="90%" onrowdatabound="gvReqList_RowDataBound" 
                        ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            
                            <asp:TemplateField HeaderText="Request">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtRequest" runat="server" oncommand="lbtRequest_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" DataFormatString="{0}" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:HyperLink runat="server" ID="hlNewRequest" NavigateUrl="#" Text="New Request" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnNeedListStatus" GroupingText="Need List">
                    
                      <asp:GridView ID="gvNeedList" runat="server" AutoGenerateColumns="False" 
                                 BorderWidth="0px" Width="100%" 
                                EmptyDataText="No need item is defined" 
                                onrowdatabound="gvNeedList_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>                                        
                                            <asp:Literal  runat="server" ID="ltType" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="ltUnit"></asp:Literal>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt.">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltAmt" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Col.">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltCollected" runat="server" />
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
                    
                    </asp:Panel>
                <asp:Panel runat="server" ID="pnVolList" GroupingText="Volunteer List">
                    Vol List</asp:Panel>
                <asp:Panel runat="server" ID="pnNewRequest" GroupingText="New Request" PopupControlID="pnNewRequest"
                    BackColor="#FFCC66" Width="500px">
                    <table border="0" cellpadding="0" cellspacing="0" width="99%">
                        <tr>
                            <td style="width: 200px;" valign="top">
                                <p>Request name<br />
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
                                    
                            </td>
                            <td valign="top">
                                <uc2:ucRequestMap ID="ucRequestMap1" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btSaveRequest" runat="server" Text="Save" 
                        onclick="btSaveRequest_Click" />
                    &nbsp;<asp:Button ID="btCancel" runat="server" Text="Cancel" />
                </asp:Panel>
                <asp:ModalPopupExtender runat="server" ID="mpeNewRequest" PopupControlID="pnNewRequest"
                    TargetControlID="hlNewRequest" BackgroundCssClass="modalBackground" 
                    CancelControlID="btCancel" DropShadow="True" />
            </td>
            <td style="width: 400px; vertical-align: top;">
                <asp:Panel runat="server" ID="pnIncident" GroupingText="Incident">
                    Incident Information
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lbIncName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbSeverity" runat="server" />,
                                <asp:Label ID="lbIncType" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status:
                            </td>
                            <td>
                                <asp:Label ID="lbStatus" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <uc1:UCIncidentMap ID="UCIncidentMap1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
