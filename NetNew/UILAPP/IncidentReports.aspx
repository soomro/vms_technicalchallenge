<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="IncidentReports" Codebehind="IncidentReports.aspx.cs" %>
  <%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:Panel runat="server" ID="pnlIncRepList">
        <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="False" Width="80%"
            OnRowDataBound="gvReports_RowDataBound" DataKeyNames="Id">
            <Columns>
                <asp:TemplateField HeaderText="Message">
                    <ItemTemplate>
                        <asp:Label ID="lbMessage" runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sent">
                    <ItemTemplate>
                        <asp:Label ID="lblSent" runat="server"></asp:Label>
                    </ItemTemplate>                  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lbType" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="lbLocation" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reporter">
                    <ItemTemplate>
                        <asp:Hyperlink ID="hlReporter" runat="server"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>

