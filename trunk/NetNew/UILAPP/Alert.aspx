<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Alert" Codebehind="Alert.aspx.cs" %>
    <%@ MasterType TypeName="SiteMaster" %>
<%@ Register Src="UControls/UCSearchVolunteer.ascx" TagName="UCSearchVolunteer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" ID="pnlAlertList">
        <asp:GridView ID="gvAlerts" runat="server" AutoGenerateColumns="False" Width="80%"
            OnRowDataBound="gvAlerts_RowDataBound" BackColor="White" BorderColor="#CC9966"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id">
            <Columns>
                <asp:TemplateField HeaderText="Message">
                    <ItemTemplate>
                        <asp:Label ID="lbMessage" runat="server"  ></asp:Label>
                    </ItemTemplate>                  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sent">
                    <ItemTemplate>
                        <asp:Label ID="lblSent" runat="server"></asp:Label>                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Search Criteria">
                    <ItemTemplate>
                        <asp:Label ID="LblSearch" runat="server"></asp:Label>
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
    <asp:Panel runat="server" ID="pnlDivForm">
        <table class="tblForm" width="100%">
            <tr>
                <td class="formField" align="left" width="50%">
                   <uc1:UCSearchVolunteer ID="ucSearchVolunteer" runat="server" />
                </td>
                <td class="value" style="width:50%" >
                 Alert Message:<br /> &nbsp;<asp:TextBox ID="txtMessage" runat="server" CssClass="tx" 
                        Height="100px"  TextMode="MultiLine" 
                        Width="90%"></asp:TextBox>
                        <br />
                          <asp:Button ID="btnSend" runat="server" CssClass="buttons" OnClick="btnSend_Click"
                        Text="Send" ValidationGroup="1" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="buttons" 
                        OnClick="btnCancel_Click" Text="Cancel" ValidationGroup="1" />
                    
                </td>
            </tr>
          
            
        </table>
    </asp:Panel>
</asp:Content>
