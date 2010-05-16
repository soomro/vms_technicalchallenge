<%@ Control Language="C#" AutoEventWireup="true" Inherits="UC_UCCreateCrisisMap" Codebehind="UCCreateCrisisMap.ascx.cs" %>
  
  <artem:GoogleMap ID="GoogleMap1" runat="server" Width="300px" Height="150px" 
             Key="ABQIAAAAC64nBBFT6BjEy-xaKDg-fhTCQnlm-Zk4MbF9g01i-wktUtPgyRSdP5g1d0wfYrLv-IjQmA9_w0iYMQ" 
              ZoomPanType="Large3D"  onclick="GoogleMap1_Click" 
             InsideUpdatePanel="True" EnableScrollWheelZoom="True"  
               EnableGoogleMapState="True" EnableGoogleBar="True">       
       
        </artem:GoogleMap>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>