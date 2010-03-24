<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; text-align:center;">
    
        <div>
        Your Name: 
        
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Your Birth Date:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Calculate My Age" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" 
                ForeColor="Red"></asp:Label>
        
            <br />
            <br />
            <br />
            Crisis Id:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Show" />
            <br />
            New Name 
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Change" />
            <br />
        
        </div>
    
    </div>


        <cc1:GMap ID="GMap1" runat="server" enableServerEvents="true" ajaxUpdateProgressMessage="updating..."
    OnMarkerClick="GMap1_MarkerClick"
    OnZoomEnd="GMap1_ZoomEnd" 
    OnMapTypeChanged="GMap1_MapTypeChanged" 
    OnClick="GMap1_Click"
    OnDragEnd="GMap1_DragEnd"
    OnDragStart="GMap1_DragStart"
    OnMoveEnd="GMap1_MoveEnd"
    OnMoveStart="GMap1_MoveStart" Key="ABQIAAAAC64nBBFT6BjEy-xaKDg-fhTCQnlm-Zk4MbF9g01i-wktUtPgyRSdP5g1d0wfYrLv-IjQmA9_w0iYMQ" />
<div id="messages1"></div>
<div id="messages2"></div>
    </form>
</body>
</html>
