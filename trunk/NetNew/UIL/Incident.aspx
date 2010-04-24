<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Incident.aspx.cs" Inherits="Incident" %>

<%@ Register src="UControls/UCMap.ascx" tagname="UCMap" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
        <table class="tblForm">
            <tr>
                <td class="formField">
                    Incident Name
                </td>
                <td class="value">
                    <asp:TextBox ID="txtName" runat="server" CssClass="tx" Width="138px"></asp:TextBox>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
                <td rowspan="10">
        <uc1:UCMap ID="UCMap1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formField">
                    Explanation
                </td>
                <td class="value">
                    <asp:TextBox ID="txtExplanation" runat="server" CssClass="tx" TextMode="MultiLine"
                        Rows="4"></asp:TextBox>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Incident Type
                </td>
                <td class="value">
                    <asp:DropDownList ID="ddlIncidentType" runat="server" OnSelectedIndexChanged="ddlRadious_SelectedIndexChanged"
                        AutoPostBack="True" CssClass="tx">
                        <asp:ListItem>Fire</asp:ListItem>
                        <asp:ListItem>Collapse</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Severity</td>
                <td class="value">
                    <asp:DropDownList ID="ddlSeverity" runat="server" OnSelectedIndexChanged="ddlRadious_SelectedIndexChanged"
                        AutoPostBack="True" CssClass="tx">
                        <asp:ListItem Value="Critical">Minor</asp:ListItem>
                        <asp:ListItem>Critical</asp:ListItem>
                        <asp:ListItem>Serious</asp:ListItem>
                        <asp:ListItem>Normal</asp:ListItem>
                        <asp:ListItem>Moderate</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Priority</td>
                <td class="value">
                    <asp:DropDownList ID="ddlPriority" runat="server" OnSelectedIndexChanged="ddlRadious_SelectedIndexChanged"
                        AutoPostBack="True" CssClass="tx">
                        <asp:ListItem Value="High">Low</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Needed Item</td>
                <td class="value">
                    <asp:TextBox ID="txtName0" runat="server" CssClass="tx" Width="138px"></asp:TextBox>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Item Amount</td>
                <td class="value">
                    <asp:TextBox ID="txtName1" runat="server" CssClass="tx" Width="138px"></asp:TextBox>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    Item Unit</td>
                <td class="value">
                    <asp:TextBox ID="txtName2" runat="server" CssClass="tx" Width="138px"></asp:TextBox>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formField">
                    &nbsp;</td>
                <td class="value">
                    &nbsp;</td>
                <td class="value" width="5px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="label">
                    &nbsp;
                    
                </td>
                <td class="value" align="right">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" 
                        onclick="btnCancel_Click"/>
                    &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btSave_Click" 
                        Text="Save" CssClass="buttons" />
                </td>
                <td class="value" align="right" width="5px">
                    &nbsp;</td>
                <td class="value" align="right">
                    &nbsp;</td>
            </tr>
        </table>
    <div style="float: left">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlRadious" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

