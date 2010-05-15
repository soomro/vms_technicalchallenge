<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCSearchVolunteer.ascx.cs"
    Inherits="UControls_UCSearchVolunteer" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    div, h1, h2, h3, h4, p, form, label, input, textarea, img, span
    {
        margin: 0;
        padding: 0;
        text-align: left;
    }
</style>
<table class="style1">
    <tr>
        <td class="formField" nowrap="nowrap" width="5%">
            Words in profile:
        </td>
    </tr>
    <tr>
        <td class="formField" nowrap="nowrap" width="5%">
            <asp:TextBox ID="txtCriteria" runat="server" AutoPostBack="True" CssClass="tx" Height="68px"
                OnTextChanged="txtCriteria_TextChanged" TextMode="MultiLine" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvVolList" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="gvVolList_RowDataBound" BackColor="White" BorderColor="#CC9966"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Volunteer Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblVolName" runat="server"></asp:Label>
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
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="txtCriteria" />
                </Triggers>

            </asp:UpdatePanel>
        </td>
    </tr>
</table>
