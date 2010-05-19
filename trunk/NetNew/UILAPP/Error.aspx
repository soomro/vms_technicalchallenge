<%@ Page Language="C#" AutoEventWireup="true" Inherits="Error" Codebehind="Error.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
        function RedirectParent() {
            //parent.location="Login.aspx";

        }
    </script>
    <link rel="Stylesheet" href="Styles/style.css" />
</head>
<body onload="javascript:RedirectParent();">
    <form id="form1" runat="server">
    <div align="center">
        &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 428px; border-right: lightgrey thin solid; border-top: lightgrey thin solid;
            border-left: lightgrey thin solid; border-bottom: lightgrey thin solid;" align="center">
            <tr>
                <td style="width: 20px; margin-top: 10px; margin-left: 20px; padding-left: 10px;
                    padding-top: 10px;" rowspan="2" valign="top">
                    <img src="Images/icons_203.gif" height="80" width="80" />
                </td>
                <td align="left" style="padding-right: 10px; padding-left: 15px; padding-bottom: 15px;
                    padding-top: 20px; font-size: 8pt;" valign="top" class="ErrorPage_ErrorMessage">
                    There is an unexpected error in the system.<br />
                    The error is registered in the system and we will work to solve it.<br />
                    
                    <br />
                    <a href="#" onclick="document.getElementById('div_hata').style.visibility='visible'">Show error details</a>
                    <br />
                    <br />
                    <div style="width: 100%; height: auto; visibility: hidden;" id="div_hata">
                        <asp:Label runat="server" ID="mesaj" Font-Bold="True"></asp:Label></div>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 10px; padding-left: 15px; padding-bottom: 15px;
                    padding-top: 20px" valign="top">
                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
