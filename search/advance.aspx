<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="advance.aspx.cs" Inherits="search_advance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="sub-list-container">
<asp:TextBox ID="search" runat="server"></asp:TextBox>
<asp:Button ID="searchBtn" runat="server" Text="Search" onclick="searchBtn_Click"/>
</div>
</asp:Content>

