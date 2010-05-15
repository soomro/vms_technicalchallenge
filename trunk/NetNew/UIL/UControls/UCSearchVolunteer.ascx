<%@ Control Language="C#" AutoEventWireup="true" Inherits="UControls_UCSearchVolunteer" Codebehind="UCSearchVolunteer.ascx.cs" %>
<style type="text/css">

.tx
{

    border: thin solid #000080;
    font-size: 11px;
    font-family: Verdana;
    font-weight: bold;
    padding: 2px;
}
</style>
                    <asp:ListBox ID="lstVolunteers" runat="server" 
    Height="284px" Width="247px" 
                        CssClass="tx" SelectionMode="Multiple">
                    </asp:ListBox>
                
