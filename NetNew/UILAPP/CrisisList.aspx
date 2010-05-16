<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="CrisisList" Codebehind="CrisisList.aspx.cs" %>

<%@ MasterType TypeName="SiteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    

                  <asp:GridView runat="server" ID="gvCrisisList" AutoGenerateColumns="False" 
                      HorizontalAlign="Left" Width="100%" 
                     
                  
                      onselectedindexchanged="gvCrisisList_SelectedIndexChanged" 
                      DataKeyNames="Id" onrowdatabound="gvCrisisList_RowDataBound" 
                      onpageindexchanging="gvCrisisList_PageIndexChanging" AllowPaging="True"
                     >
                    
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
                    
                 </asp:GridView>

.
 
</asp:Content>

