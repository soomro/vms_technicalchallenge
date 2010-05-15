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
                    <asp:GridView runat="server" ID="gvReqList" AutoGenerateColumns="False" EmptyDataText="This incident has no request"
                        ShowHeader="False" Width="90%" OnRowDataBound="gvReqList_RowDataBound" 
                        CssClass="bluestyle">
                        <Columns>
                            <asp:TemplateField HeaderText="Request">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtRequest" runat="server" OnCommand="lbtRequest_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                    <asp:HyperLink runat="server" ID="hlEditRequest">
                                    <asp:Image  ImageUrl="~/Images/edit.gif" runat="server" ToolTip="Edit Request"
                                        ID="imgbtEdit" />
                                    </asp:HyperLink>

                                    
                                   
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                    </asp:GridView>
                    <br />
                        
                        <a href="#" runat="server" ID="hlNewRequest"  
                           ><img src="./Images/add.png" width="30px" height="30px" alt="Add new" /> Add new request </a>
                       
                    
                </asp:Panel>
                <asp:Panel runat="server" ID="pnNeedListStatus" GroupingText="Need List">
                    <asp:GridView ID="gvNeedList" runat="server" AutoGenerateColumns="False"
                        Width="100%" EmptyDataText="No need item is defined" 
                        OnRowDataBound="gvNeedList_RowDataBound" CssClass="smallbluestyle">
                        <Columns>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Literal runat="server" ID="ltType" />
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
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtRemove" runat="server" AlternateText="Remove" ImageUrl="~/Images/delete.gif"
                                        OnCommand="ibtRemove_Command" ToolTip="Remove" Width="15px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Font-Size="9pt" Font-Underline="True" />
                    </asp:GridView>
                

                    <span class="strong">Volunteer List</span><br /> 
                    <asp:GridView runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="2" ForeColor="Black" GridLines="None" ID="gvVolunteers" 
                        EmptyDataText="This request has not been sent to any volunteer" 
                        Width="100%" onrowdatabound="gvVolunteers_RowDataBound" >
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                           <asp:TemplateField HeaderText="Vol. Name">
                                <ItemTemplate> <asp:HyperLink ID="hlVolName" runat="server">Vol Name</asp:HyperLink></ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response">
                                <ItemTemplate> <asp:Label ID="lbResponse" runat="server">Response</asp:Label></ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplied">
                                <ItemTemplate> <asp:Label ID="lbSupplied" runat="server">Supplied</asp:Label></ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        <HeaderStyle Font-Bold="True" Font-Size="9pt" Font-Underline="True" 
                            BackColor="Tan" />
                    </asp:GridView>
                    
                    </asp:Panel>
                
            </td>
            <td style="width: 400px; vertical-align: top;">
                <asp:Panel runat="server" ID="pnIncident" GroupingText="Incident">
                   
                    <table width="98%" class="formTable">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label runat="server" ID="lbIncName" class="strong"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td class="label">
                                Status
                            </td>
                            <td class="value" >: <asp:Label ID="lbStatus" runat="server" />
                            </td>
                            
                        </tr>
                         <tr>
                        <td class="label">
                               Severity-Type    
                            </td>
                            <td class="value" >: <asp:Label ID="lbSeverity" runat="server" />-
                                <asp:Label ID="lbIncType" runat="server" />
                              
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="2"><div>
                                <asp:GridView runat="server" AutoGenerateColumns="False" ID="gvIncidentNeeds" 
                                    EmptyDataText="Incident has no need list!" 
                                    onrowdatabound="gvIncidentNeeds_RowDataBound" CssClass="bluestyle">
                             
                                    <Columns>
                                        <asp:TemplateField HeaderText="Item Type">
                                            <ItemTemplate><asp:Label ID="lbType" runat="server" /></ItemTemplate>                                             
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Metric">
                                             <ItemTemplate><asp:Label ID="lbMetric" runat="server" /></ItemTemplate> 
                                             </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                             <ItemTemplate><asp:Label ID="lbAmount" runat="server" /></ItemTemplate> 
                                             </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplied">
                                             <ItemTemplate><asp:Label ID="lbSupplied" runat="server" /></ItemTemplate> 
                                             </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                             </div>
                            </td>
                        </tr>
                    </table>
                    <uc1:UCIncidentMap ID="UCIncidentMap1" runat="server" width="98%"/>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
