<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LotBankingCrux_v_1._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <!-- style setup for Maps API -->
    <style type="text/css">
        html {
            height: 100%;
        }

        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map-canvas {
            height: 100%;
        }
    </style>
    <!-- Javascript for Maps API -->
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?sensor=false">
    </script>
    <script src="../Scripts/bargraph-v1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function initialize() {
            var mapOptions = {
                //we can populate this region from data pulled dynamically or have the user
                //input location for the database <--easiest
                center: new google.maps.LatLng(33.4995417, -111.9272479),
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map-canvas"),
                mapOptions);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <div class="menubar">
        <div class="table">
            <ul id="horizontal-list">
                <li>DOCUMENTATION</li>
                <li>PERFORMANCE METRICS</li>
                <li>SALES REPORT</li>
                <li>TRAFFIC REPORT</li>
                <li>LOCATION</li>
            </ul>
        </div>


    </div>
    <div class="colmask threecol">

        <div class="colmid">
            <div class="colleft">
                <div class="col1">
                    <!-- Column 2 start -->
                    <div class="position">
                        <div class="graphcontainer">
                            <div class="bar1" id="bar1">
                                <div class="percent">
                                    <span style="width: 100%;"></span>
                                </div>
                                <div class="circle">
                                    <span>$0</span>
                                </div>
                                <div class="text">
                                    <input type="text" class="input1" value="0" />
                                    <small>Construction Cost over Expected Cost</small>
                                </div>
                            </div>
                            <div class="bar2" id="bar2">
                                <div class="percent">
                                    <span style="width: 100%;"></span>
                                </div>
                                <div class="circle">
                                    <span>$0</span>
                                </div>
                                <div class="text">
                                    <input type="text" class="input2" value="0" />
                                    <small>Lots purchased over lots available</small>
                                </div>
                            </div>
                            <div class="bar3" id="bar3">
                                <div class="percent">
                                    <span style="width: 100%;"></span>
                                </div>
                                <div class="circle">
                                    <span>$0</span>
                                </div>
                                <div class="text">
                                    <input type="text" class="input3" value="0" />
                                    <small>Lots sold over lots available</small>
                                </div>
                            </div>
                        </div>
                        <div class="bottomhalf">
                            <div class="tscontainer">
                                <img src="http://localhost:4838/Images/delete_salesTraffic.png" height="100%" width="100%" />
                            </div>
                            <div class="mapcontainer">
                                <!-- Map display -->
                                <div id="map-canvas"></div>
                            </div>
                        </div>
                        <!-- Column 2 end -->
                    </div>
                </div>
                <div class="col2">
                    <!-- Column 1 start -->
                    <table class="tasklist">
                        <tr>
                            <th>TASK LIST</th>
                        </tr>
                        <tr>
                            <td>row 1, cell 1</td>
                        </tr>
                        <tr>
                            <td>row 1, cell 2</td>
                        </tr>
                    </table>


                    <!-- Column 1 end -->
                </div>
                <div class="col3">
                    <!-- Column 3 start -->
                    <div class="title">
                        Builders
                    </div>
                    <!-- Column 3 end -->
                </div>
            </div>
        </div>
    </div>


</asp:Content>
