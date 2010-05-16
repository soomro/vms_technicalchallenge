<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="IncidentReports" Codebehind="IncidentReports.aspx.cs" %>
  <%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:Panel runat="server" ID="pnlIncRepList">
        <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="False" Width="80%"
            OnRowDataBound="gvReports_RowDataBound" BackColor="White" BorderColor="#CC9966"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id">
            <Columns>
                <asp:TemplateField HeaderText="Message">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="tx" Height="76px" TextMode="MultiLine"
                            Width="374px"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sent">
                    <ItemTemplate>
                        <asp:Label ID="lblSent" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="LblLocation" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>

