<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCCreateCrisisMap.ascx.cs" Inherits="UC_UCCreateCrisisMap" %>
  
  <artem:GoogleMap ID="GoogleMap1" runat="server" Width="300px" Height="300px" 
             Key="ABQIAAAAC64nBBFT6BjEy-xaKDg-fhTCQnlm-Zk4MbF9g01i-wktUtPgyRSdP5g1d0wfYrLv-IjQmA9_w0iYMQ" 
              ZoomPanType="Large3D"  onclick="GoogleMap1_Click" 
             InsideUpdatePanel="True" EnableScrollWheelZoom="True"  
               EnableGoogleMapState="True">       
       
        </artem:GoogleMap>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="true"></asp:Label>