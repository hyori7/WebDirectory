<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true"
    CodeFile="photo_upload.aspx.cs" Inherits="client_photo_upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sub-container">
        <div>
            Upload Photo:
            <asp:FileUpload ID="photo_upload" runat="server" />
        </div>
        <div>
            Insert Caption:
        </div>
        <div>
            <asp:TextBox ID="caption" runat="server" TextMode="MultiLine" Width="800px" Height="44px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="upload" runat="server" Text="Upload" OnClick="upload_Click" />
        </div>
        <asp:HiddenField ID="profileID" runat="server" />
        <asp:HiddenField ID="profileName" runat="server" />
    </div>
</asp:Content>
