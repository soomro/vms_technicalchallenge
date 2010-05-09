<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IncidentList.aspx.cs" Inherits="IncidentList" %>
<%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label   runat="server" ID="lbTitle" Text="Incident list of: "/> 
    <asp:HyperLink ID="hlCrisis" runat="server" />
    <asp:GridView runat="server" ID="gvIncidents" AutoGenerateColumns="False" Width="100%"
        DataKeyNames="Id" AllowPaging="True" 
        onpageindexchanging="gvIncidents_PageIndexChanging" 
        onrowdatabound="gvIncidents_RowDataBound" PageSize="10" 
    EmptyDataText="This crisis doesnt contain any incident!"  >
        <Columns>
            <asp:TemplateField HeaderText="Name" 
                SortExpression="Name">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlName"></asp:HyperLink>                 
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status" > 
                <ItemTemplate>
                    <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("IncidentStatusVal") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Severity " SortExpression="SeverityVal">
                <ItemTemplate>
                    <asp:Label ID="lbSeverity" runat="server" Text='<%# Bind("SeverityVal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Incident Type" 
                SortExpression="IncidentTypeVal">
                <ItemTemplate>
                    <asp:Label ID="lbIncidentType" runat="server" Text='<%# Bind("IncidentTypeVal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Short Address" SortExpression="ShortAddress">
                <ItemTemplate>
                    <asp:Label ID="lbShortAddress" runat="server" Text='<%# Bind("ShortAddress") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

