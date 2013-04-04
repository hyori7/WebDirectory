<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="list.aspx.cs" Inherits="search_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function goto(name, id) {
            document.location.href = "../client/profile.aspx?profile=" + name + "&id=" + id;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sub-list-container">
        <asp:GridView ID="searchView" runat="server" AutoGenerateColumns="False" GridLines="None"
            CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Result">
                    <ItemTemplate>
                        <div id="search-view-container">
                            <div id="search-view" onclick="goto('<%# Eval("name")%>'  ,  '<%# Eval("id") %>')">
                                <div id="name-style">
                                    <%#"<a href=\"javascript:goto('" + Eval("name") + "', '"+ Eval("id") + "');\">" + Eval("name") + "</a>"%>
                                </div>
                                <div>
                                    Contact:
                                    <asp:Label ID="phone" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                                </div>
                                <div>
                                    Location:
                                    <asp:Label ID="address" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <div id="page-button">
            <asp:LinkButton ID="previous" runat="server" Text="<< previous" OnClick="previous_Click"></asp:LinkButton>&nbsp;
            <asp:DropDownList ID="dropDownPage" runat="server" OnSelectedIndexChanged="dropDownPage_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            &nbsp;
            <asp:LinkButton ID="next" runat="server" Text="next >>" OnClick="next_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
