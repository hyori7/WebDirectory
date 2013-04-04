<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true"
    CodeFile="photo.aspx.cs" Inherits="client_photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            photo = $("#<%= checkImage.ClientID %>").val();
            if (photo != "") {
                $('#popup-image-container').show();
            }

            $('#inner-left-blank').click(function () {
                if ($('#popup-image-container').is(":visible")) {
                    $('#popup-image-container').hide();
                }
            });

            $('#inner-right-blank').click(function () {
                if ($('#popup-image-container').is(":visible")) {
                    $('#popup-image-container').hide();
                }
            });

//            $('#inner-popup').mousemove(function () {
//                $('#caption-wrapper').slideDown("fast");
//            });

//            $('#inner-popup').mouseleave(function () {
//                $('#caption-wrapper').slideUp("fast");
//            });
        });

        



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sub-container">
        <div id="popup-image-container">
        <div id="inner-left-blank"></div>
        <div id="inner-popup">
            <div id="image-container">
                <div id="image-box">
                    <asp:Image ID="imagePop" runat="server"/>
                   
                </div>
            </div>
           
            <div id="caption-container">
             <div id="caption-box"></div>
             <div id="caption-font">
                    <asp:Label ID="caption" runat="server"></asp:Label>
                    </div>
                
                </div>
                 <div id="inner-right-blank"></div>
            </div>
           
        </div>
        <div id="photo-list">
        <asp:DataList ID="photoView" runat="server" RepeatColumns="3" OnItemCommand="photo_ItemCommand">
            <ItemTemplate>
                <div class="img">
                    <asp:HiddenField ID="imageId" runat="server" Value='<%# Eval("id") %>' />
                    <div class="img-inner">
                    <asp:ImageButton ID="photo" runat="server" ImageUrl='<%# Bind("path") %>' CommandName="photoCall" /></div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
    </div>
    <div>
    <asp:HiddenField ID="profileName" runat="server" />
        <asp:HiddenField ID="profileID" runat="server" />
    </div>
    <div>
        <asp:HiddenField ID="checkImage" runat="server" />
    </div>
</asp:Content>
