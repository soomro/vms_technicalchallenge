<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CrisisList.aspx.cs" Inherits="CrisisList" %>

<%@ MasterType TypeName="SiteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            
             <td align="left" style="text-align:left">
                  <asp:GridView runat="server" ID="gvCrisisList" AutoGenerateColumns="False" 
                       
                     GridLines="None" HorizontalAlign="Left" Width="100%" 
                     
                      CssClass="mGrid"  PagerStyle-CssClass="pgr" 
                      AlternatingRowStyle-CssClass="alt" 
                      onselectedindexchanged="gvCrisisList_SelectedIndexChanged" 
                      DataKeyNames="Id" onrowdatabound="gvCrisisList_RowDataBound" onpageindexchanging="gvCrisisList_PageIndexChanging"
                     >
                     <AlternatingRowStyle HorizontalAlign="Left"   />
                     <Columns>
                         <asp:TemplateField ShowHeader="False" HeaderText="Crisis Name">
                             <ItemTemplate>
                                 &nbsp;&nbsp;<asp:LinkButton ToolTip="View crisis information" ID="lbtName" runat="server" CausesValidation="False" 
                                     CommandName="Select" Text='<%# Bind("Name") %>'></asp:LinkButton>
                                    <asp:HiddenField runat="server" ID="hdId" Value='<%# Bind("Id") %>' />
                             </ItemTemplate>
                         </asp:TemplateField>                        
                      
                         <asp:TemplateField HeaderText="Crisis Type" SortExpression="CrisisTypeVal">
                             <ItemTemplate>
                                 <asp:Label ID="lbCrisisType" runat="server" Text='<%# Bind("CrisisTypeVal") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date Created" SortExpression="DateCreated">
                             <ItemTemplate>
                                 <asp:Label ID="lbDateCreated" runat="server" Text='<%# Bind("DateCreated") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date Closed" SortExpression="DateClosed">
                             <ItemTemplate>
                                 <asp:Label ID="lbDateClosed" runat="server" Text='<%# Bind("DateClosed") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>                         
                     </Columns>
                     <FooterStyle   />
                     <HeaderStyle HorizontalAlign="Left"  />
                     <PagerStyle   />
                     <RowStyle HorizontalAlign="Left"  />
                     <SelectedRowStyle   />
                     <SortedAscendingCellStyle BackColor="#FAFAE7" />
                     <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                     <SortedDescendingCellStyle BackColor="#E1DB9C" />
                     <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                 </asp:GridView>
                 
            </td>
             
        </tr>
    </table>
   <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                     ConnectionString="name=ApolloEntities" DefaultContainerName="ApolloEntities" 
                     EnableFlattening="False" EntitySetName="Crises" EntityTypeFilter="Crisis" 
                     
        Select="it.[Name], it.[StatusVal], it.[CrisisTypeVal], it.[DateCreated], it.[DateClosed], it.[Id]" 
        OrderBy="it.[DateCreated] desc">
                 </asp:EntityDataSource>
 
</asp:Content>

