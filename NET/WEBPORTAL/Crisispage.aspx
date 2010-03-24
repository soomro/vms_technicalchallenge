<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="true" CodeFile="Crisispage.aspx.cs" Inherits="Crisispage" %>

<%@ Register src="UC/ucEnumSelector.ascx" tagname="ucEnumSelector" tagprefix="uc1" %>
<%@ MasterType TypeName="PageMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View runat="server">
            <table class="tblForm">       
            <tr>
                <td class="label">
                    Crisis Name</td>
                <td class="value">
                    <asp:TextBox ID="txCrisisName" runat="server" CssClass="tx"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label">
                    Explanation</td>
                <td class="value">
                    <asp:TextBox ID="txExplanation" runat="server" CssClass="tx" 
                        TextMode="MultiLine" Rows="4"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label">
                    Crisis Type</td>
                <td class="value">
                    <uc1:ucEnumSelector ID="ucEnumSelector1" runat="server" CssClass="options" 
                         />
                </td>
            </tr>
            <tr>
                <td class="label">
                    &nbsp;</td>
                <td class="value">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="label">
                    &nbsp;</td>
                <td class="value" align="right">
                    <asp:Button ID="btSave" runat="server" onclick="btSave_Click" Text="Save" />
                </td>
            </tr>
        </table>
        </asp:View>
        <asp:View runat="server">
        
        </asp:View>
    </asp:MultiView>
    

</asp:Content>

