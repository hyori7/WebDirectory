<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="register_client.aspx.cs" Inherits="admin_register_client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<asp:Label ID="companyLbl" runat="server" Text="Company Name: "></asp:Label>
<asp:TextBox ID="company" runat="server"></asp:TextBox>
</div>
<div>
<asp:Label ID="ownerLbl" runat="server" Text="Owner Name: "></asp:Label>
<asp:TextBox ID="owner" runat="server"></asp:TextBox>
</div>
<div>
<asp:Label ID="phoneLbl" runat="server" Text="Contact Number: "></asp:Label>
<asp:TextBox ID="phone" runat="server"></asp:TextBox>
</div>
<div>
<asp:Label ID="addressLbl" runat="server" Text="Address: "></asp:Label>
<asp:TextBox ID="address" runat="server"></asp:TextBox>
</div>
<div>
<asp:Label ID="emailLbl" runat="server" Text="Email: "></asp:Label>
<asp:TextBox ID="email" runat="server"></asp:TextBox>
</div>
<div>
<asp:Button ID="submit" runat="server" Text="Submit" onclick="submit_Click"/>
</div>
</asp:Content>

