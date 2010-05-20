<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="ManReg" Codebehind="ManReg.aspx.cs" %>

<%@ MasterType TypeName="SiteMaster" %>

<%@ Register src="UControls/ucEnumSelector.ascx" tagname="ucEnumSelector" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 10px;
            font-family: sans-serif;
            color: #800000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:Panel runat="server" id="pnlDivForm"> 
   <table class="tblForm" >
        <tr>
            <td class="style1">
                Full Name:</td>
            <td class="value">
                <asp:TextBox ID="txtFullName" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Birthdate:<br />
                (yyyy-mm-dd)</td>
            <td class="value">
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="tx"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtBirthDate" 
                    ValidationExpression="^(19[0-9]{2}|2[0-9]{3})-(0[1-9]|1[012])-([123]0|[012][1-9]|31)$" 
                    ValidationGroup="1">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Gender:</td>
            <td class="value">
                <uc1:ucEnumSelector ID="ucEnumSelectorGender" runat="server"></uc1:ucEnumSelector>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="value">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Expertise in<br />
                crisi handling:</td>
            <td class="value">
                <asp:TextBox ID="txtExpertiseCrisisTypes" runat="server" CssClass="tx" Rows="4" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Country:</td>
            <td class="value">
                <asp:TextBox ID="txtCountry" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                City:</td>
            <td class="value">
                <asp:TextBox ID="txtCity" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Street:</td>
            <td class="value">
                <asp:TextBox ID="txtStreet" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                House No.</td>
            <td class="value">
                <asp:TextBox ID="txtHouseNo" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Flat No.:</td>
            <td class="value" style="margin-left: 40px">
                <asp:TextBox ID="txtFlatNo" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Postal code:</td>
            <td class="value">
                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Username:</td>
            <td class="value">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="tx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Password:</td>
            <td class="value">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="tx" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="value">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" ValidationGroup="1" CssClass="buttons" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                     Text="Cancel" CssClass="buttons" />
            </td>
        </tr>
    </table> 
    </asp:Panel>
   
    <asp:Panel runat="server" ID="pnlAdmin" Visible="False">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <asp:GridView ID="gvuManagers" runat="server" AutoGenerateColumns="False" 
            Width="80%" onrowdatabound="gvuManagers_RowDataBound" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                DataKeyNames="Id" EmptyDataText="No manager registration is found!">
        <Columns>
            <asp:TemplateField HeaderText="Approved">
                <ItemTemplate>
                    <asp:CheckBox ID="chkApproved" runat="server" AutoPostBack="True" 
                        oncheckedchanged="chkApproved_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Full Name">
                <ItemTemplate>
                    <asp:Label ID="lblFullName" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtRemove" runat="server" AlternateText="Remove" 
                        ImageUrl="~/Images/delete.gif" OnCommand="ibtRemove_Command" ToolTip="Remove" 
                        Width="15px" />
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
    </asp:UpdatePanel>
  
        <br />
    </asp:Panel>
</asp:Content>


