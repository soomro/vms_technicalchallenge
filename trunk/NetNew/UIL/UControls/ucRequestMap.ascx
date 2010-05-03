<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRequestMap.ascx.cs" Inherits="UControls_ucRequestMap" %>

<asp:UpdatePanel runat="server" ID="up">
    <ContentTemplate>
     <artem:GoogleMap ID="GoogleMap1" runat="server" Width="300px" Height="300px" 
             Key="ABQIAAAAC64nBBFT6BjEy-xaKDg-fhTCQnlm-Zk4MbF9g01i-wktUtPgyRSdP5g1d0wfYrLv-IjQmA9_w0iYMQ" 
              ZoomPanType="SmallZoom"   
             InsideUpdatePanel="True" EnableScrollWheelZoom="True"  
               EnableGoogleMapState="True" EnableGoogleBar="false" EnableDragging="false" EnableMarkerManager="True" EnableReverseGeocoding="True" ShowScaleControl="False"
               Latitude="42.1229"
        Longitude="24.7879" Zoom="4" >       
       <Polygons>
            <artem:GooglePolygon FillColor="Red" FillOpacity=".8" StrokeColor="Blue" StrokeWeight="2"
                EnableDrawing="false" EnableEditing="true">
                <artem:GoogleLocation Latitude="37.97918" Longitude="23.716647" />
                <artem:GoogleLocation Latitude="41.036501" Longitude="28.984895" />
                <artem:GoogleLocation Latitude="44.447924" Longitude="26.097879" />
                <artem:GoogleLocation Latitude="44.802416" Longitude="20.465601" /> 
            </artem:GooglePolygon>
        </Polygons>
        </artem:GoogleMap>
      
    </ContentTemplate>
</asp:UpdatePanel>
