<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true"
    CodeFile="new_profile.aspx.cs" Inherits="client_new_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sub-container">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" />
        <div>
            <asp:Label ID="nameLbl" runat="server" Text="Enter a business title/name: "></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="name" runat="server" Width="600px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="trading_hourLbl" runat="server" Text="Trading hour: "></asp:Label>
        </div>
        <div class="htmleditor">
            <asp:TextBox ID="trading_hour" runat="server" TextMode="MultiLine" Width="600px"
                Height="80px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="phoneLbl" runat="server" Text="Contact Number: "></asp:Label>
        </div>
        <div class="htmleditor">
            <asp:TextBox ID="phone" runat="server" TextMode="MultiLine" Width="600px" Height="80px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="addressLbl" runat="server" Text="Location: "></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="address" runat="server" Width="600px" TextMode="MultiLine" Height="46px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="emailLbl" runat="server" Text="Email: "></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="email" runat="server" Width="250px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="summaryLbl" runat="server" Text="About us: "></asp:Label>
        </div>
        <div class="htmleditor">
            <asp:TextBox ID="summary" runat="server" TextMode="MultiLine" Width="600px" Height="120px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Submit" />
        </div>
    </div>
    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender" TargetControlID="trading_hour"
        runat="server">
        <Toolbar>
            <ajaxToolkit:Bold />
            <ajaxToolkit:Italic />
            <ajaxToolkit:Underline />
            <ajaxToolkit:JustifyLeft />
            <ajaxToolkit:JustifyCenter />
            <ajaxToolkit:JustifyRight />
            <ajaxToolkit:JustifyFull />
            <ajaxToolkit:InsertOrderedList />
            <ajaxToolkit:InsertUnorderedList />
            <ajaxToolkit:CreateLink />
            <ajaxToolkit:ForeColorSelector />
        </Toolbar>
    </ajaxToolkit:HtmlEditorExtender>
    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="phone"
        runat="server">
        <Toolbar>
            <ajaxToolkit:Bold />
            <ajaxToolkit:Italic />
            <ajaxToolkit:Underline />
            <ajaxToolkit:JustifyLeft />
            <ajaxToolkit:JustifyCenter />
            <ajaxToolkit:JustifyRight />
            <ajaxToolkit:JustifyFull />
            <ajaxToolkit:InsertOrderedList />
            <ajaxToolkit:InsertUnorderedList />
            <ajaxToolkit:CreateLink />
            <ajaxToolkit:ForeColorSelector />
        </Toolbar>
    </ajaxToolkit:HtmlEditorExtender>
    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender2" TargetControlID="summary"
        runat="server">
        <Toolbar>
            <ajaxToolkit:Bold />
            <ajaxToolkit:Italic />
            <ajaxToolkit:Underline />
            <ajaxToolkit:JustifyLeft />
            <ajaxToolkit:JustifyCenter />
            <ajaxToolkit:JustifyRight />
            <ajaxToolkit:JustifyFull />
            <ajaxToolkit:InsertOrderedList />
            <ajaxToolkit:InsertUnorderedList />
            <ajaxToolkit:CreateLink />
            <ajaxToolkit:ForeColorSelector />
        </Toolbar>
    </ajaxToolkit:HtmlEditorExtender>
    <asp:HiddenField ID="profileID" runat="server" />
    <asp:HiddenField ID="profileName" runat="server" />
</asp:Content>
