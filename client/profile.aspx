<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true"
    CodeFile="profile.aspx.cs" Inherits="client_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function InitializeMap() {
            var myOptions =
{
    zoom: 13,
    mapTypeId: google.maps.MapTypeId.ROADMAP,
    disableDefaultUI: true
};
            geocoder = new google.maps.Geocoder();

            address = document.getElementById('<%= address.ClientID %>').innerHTML;
            geocoder.geocode({ 'address': address }, function (results, status) {
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });

            });
            map = new google.maps.Map(document.getElementById("map"), myOptions);

        }

        window.onload = InitializeMap;
        $(document).ready(function () {
            rating1 = $("#<%= rating1.ClientID %>").val();
            rating2 = $("#<%= rating2.ClientID %>").val();
            rating3 = $("#<%= rating3.ClientID %>").val();
            rating4 = $("#<%= rating4.ClientID %>").val();
            rating5 = $("#<%= rating5.ClientID %>").val();
            document.getElementById('rating-bar-one').style.width = rating1 + "%";
            document.getElementById('rating-bar-two').style.width = rating2 + "%";
            document.getElementById('rating-bar-three').style.width = rating3 + "%";
            document.getElementById('rating-bar-four').style.width = rating4 + "%";
            document.getElementById('rating-bar-five').style.width = rating5 + "%";

            rateStatus = $("#<%= rating_status.ClientID %>").val();
            if (rateStatus == "1") {
                $('#user-rating-container').show();
            }
            if (rateStatus == "2") {
                $('#login-rating-container').show();
            }
            if (rateStatus == "3") {
                $('#user-rating-container').show();
            }
        });

        $(function () {
            var icons = {
                header: "ui-icon ui-icon-triangle-1-e",
                activeHeader: "ui-icon ui-icon-triangle-1-s"
            };
            $("#accordion").accordion({
                icons: icons,
                heightStyle: "content"
            });

            $("#accordion").accordion("option", "icons", icons);

        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sub-container">
        <div id="mid-profile-container">
            <div id="profile-name-div">
                <div id="profile-name-font">
                    <asp:Label ID="nameLbl" runat="server" class="profile-content-header"></asp:Label>
                </div>
            </div>
            <div>
                <asp:Label ID="address" runat="server"></asp:Label></div>
            <div class="profile-img-content">
                <div class="div-img">
                    <img src="../wImage/phone_icon.jpg" /></div>
                <div class="div-label">
                    <asp:Label ID="phone" runat="server"></asp:Label></div>
            </div>
            <div class="profile-img-content">
                <div class="div-img">
                    <img src="../wImage/email_icon.jpg" /></div>
                <div class="div-label">
                    <asp:Label ID="email" runat="server"></asp:Label></div>
            </div>
            <div class="profile-bottom-border">
            </div>
            <div id="rating-outer-container">
                <div id="rating-container">
                    <div>
                        <div class="rateLabel">
                            Excellent</div>
                        <div class="div-rating-bar">
                            <div id="rating-bar-one">
                            </div>
                        </div>
                        <div class="div-rating-number">
                            <asp:Label ID="numRated1" runat="server"></asp:Label></div>
                    </div>
                    <div>
                        <div class="rateLabel">
                            Good</div>
                        <div class="div-rating-bar">
                            <div id="rating-bar-two">
                            </div>
                        </div>
                        <div class="div-rating-number">
                            <asp:Label ID="numRated2" runat="server"></asp:Label></div>
                    </div>
                    <div>
                        <div class="rateLabel">
                            Average</div>
                        <div class="div-rating-bar">
                            <div id="rating-bar-three">
                            </div>
                        </div>
                        <div class="div-rating-number">
                            <asp:Label ID="numRated3" runat="server"></asp:Label></div>
                    </div>
                    <div>
                        <div class="rateLabel">
                            Poor</div>
                        <div class="div-rating-bar">
                            <div id="rating-bar-four">
                            </div>
                        </div>
                        <div class="div-rating-number">
                            <asp:Label ID="numRated4" runat="server"></asp:Label></div>
                    </div>
                    <div>
                        <div class="rateLabel">
                            Terrible</div>
                        <div class="div-rating-bar">
                            <div id="rating-bar-five">
                            </div>
                        </div>
                        <div class="div-rating-number">
                            <asp:Label ID="numRated5" runat="server"></asp:Label></div>
                    </div>
                    <div id="score-rating">
                        Rating:
                        <asp:Label ID="totalRatingLbl" runat="server"></asp:Label>/5
                    </div>
                </div>
                <div id="user-rating-container">
                    <asp:RadioButtonList ID="radioRate" runat="server" Font-Size="Smaller" CellPadding="0"
                        CellSpacing="0" Height="80px">
                        <asp:ListItem Value="5">Excellent</asp:ListItem>
                        <asp:ListItem Value="4">Good</asp:ListItem>
                        <asp:ListItem Value="3">Average</asp:ListItem>
                        <asp:ListItem Value="2">Poor</asp:ListItem>
                        <asp:ListItem Value="1">Terrible</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="rateButton" runat="server" OnClick="rateClick" Text="Rate" />
                </div>
                <div id="login-rating-container">
                    Please login to rate this!
                </div>
            </div>
            <div class="profile-bottom-border">
            </div>
            <div>
                <div id="accordion">
                    <div class="accordion-header">
                        Description</div>
                    <div>
                        <p>
                            <asp:Label ID="summary" runat="server"></asp:Label></p>
                    </div>
                    <div class="accordion-header">
                        Trading Hour</div>
                    <div>
                        <p>
                            <asp:Label ID="trading_hour" runat="server"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div>
                <asp:Button ID="edit" runat="server" Text="Edit" OnClick="edit_Click" Visible="false" />
            </div>
            <asp:HiddenField ID="profile_name" runat="server" />
            <asp:HiddenField ID="profile_id" runat="server" />
            <asp:HiddenField ID="rating_status" runat="server" />
        </div>
        <div id="right-profile-container">
            <div id="map">
            </div>
        </div>
        <asp:HiddenField ID="rating1" runat="server" />
        <asp:HiddenField ID="rating2" runat="server" />
        <asp:HiddenField ID="rating3" runat="server" />
        <asp:HiddenField ID="rating4" runat="server" />
        <asp:HiddenField ID="rating5" runat="server" />
    </div>
</asp:Content>
