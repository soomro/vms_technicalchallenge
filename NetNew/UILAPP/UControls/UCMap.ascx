<%@ Control Language="C#" AutoEventWireup="true" Inherits="UCMap" Codebehind="UCMap.ascx.cs" %>

           
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
    RenderMode="Inline">
    <ContentTemplate>

         <artem:GoogleMap ID="GoogleMap1" runat="server" Width="100%" Height="400px" 
             Key="ABQIAAAAC64nBBFT6BjEy-xaKDg-fhTCQnlm-Zk4MbF9g01i-wktUtPgyRSdP5g1d0wfYrLv-IjQmA9_w0iYMQ" 
              ZoomPanType="Large3D"  
             InsideUpdatePanel="True" EnableScrollWheelZoom="True"  
               >       
       
        </artem:GoogleMap>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>


    </ContentTemplate>
</asp:UpdatePanel>

