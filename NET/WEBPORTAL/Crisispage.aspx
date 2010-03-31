<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.master" AutoEventWireup="true" CodeFile="Crisispage.aspx.cs" Inherits="Crisispage" %>

<%@ Register src="UC/ucEnumSelector.ascx" tagname="ucEnumSelector" tagprefix="uc1" %>
<%@ MasterType TypeName="PageMaster" %>
<%@ Register src="UC/UCMap.ascx" tagname="UCMap" tagprefix="uc2" %>
<%@ Register src="UC/UCCreateCrisisMap.ascx" tagname="UCCreateCrisisMap" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="float:left;">
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
                    Radious(km)</td>
                <td class="value">
                    <asp:DropDownList ID="ddlRadious" runat="server" 
                        onselectedindexchanged="ddlRadious_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem Value="10">40</asp:ListItem>
                        <asp:ListItem Value="20">80</asp:ListItem>
                        <asp:ListItem Value="30">120</asp:ListItem>
                        <asp:ListItem Value="40">160</asp:ListItem>
                        <asp:ListItem Value="50">200</asp:ListItem>
                        <asp:ListItem Value="60">240</asp:ListItem>
                        <asp:ListItem Value="70">280</asp:ListItem>
                        <asp:ListItem Value="80">320</asp:ListItem>
                        <asp:ListItem Value="90">360</asp:ListItem> 
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="label">
                    &nbsp;</td>
                <td class="value" align="right">
                    <asp:Button ID="Button1" runat="server" Text="Cancel" onclick="Button1_Click" />
                    &nbsp;<asp:Button ID="btSave" runat="server" onclick="btSave_Click" Text="Save" />
                </td>
            </tr>
        </table>
           </div>
           <div style="float:left"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <uc3:UCCreateCrisisMap ID="UCCreateCrisisMap1" runat="server" />
                         
                    </ContentTemplate>
                    <Triggers>
                        
        <asp:AsyncPostBackTrigger ControlID="ddlRadious" 
                            EventName="SelectedIndexChanged" />
                        
 </Triggers>
            </asp:UpdatePanel>
               
           
           </div>
   
    

</asp:Content>

