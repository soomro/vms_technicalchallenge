<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="ProgressReports" Codebehind="ProgressReports.aspx.cs" %>
<%@ MasterType TypeName="SiteMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView runat="server" ID="gvProgressReports" AutoGenerateColumns="False" Width="100%"
        DataKeyNames="Id" AllowPaging="True" 
        onpageindexchanging="gv_PageIndexChanging" 
        onrowdatabound="gv_RowDataBound" PageSize="10" 
    EmptyDataText="No progress report has been reported for this incident!"  >
        <Columns>       
        <asp:TemplateField HeaderText="Reporter " SortExpression="Reporter">
                <ItemTemplate>
                    <asp:Label ID="lbVolunteer" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>    
        <asp:TemplateField HeaderText="Report Text " SortExpression="ReportText">
                <ItemTemplate>
                    <asp:Label ID="lbReportText" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status" > 
                <ItemTemplate>
                    <asp:Label ID="lbStatus" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Sent" SortExpression="DateSent">
                <ItemTemplate>
                    <asp:Label ID="lbDateSent" runat="server"  ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
             
            
        </Columns>
    </asp:GridView>
</asp:Content>

