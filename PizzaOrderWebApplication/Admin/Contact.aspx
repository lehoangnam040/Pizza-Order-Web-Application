<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" 
    AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PizzaOrderWebApplication.Admin.Contact" %>
<asp:Content ContentPlaceHolderID="Navigation" runat="server">
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/OrderList.aspx">Orders</asp:HyperLink>
    </li>
    <li class="active">
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Contact.aspx">Contact</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Logout.aspx">Log out</asp:HyperLink>
    </li>
</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="gvContact" CssClass="table table-responsive" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="ContactMessage" HeaderText="Contact Message" SortExpression="ContactMessage" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#d9534f" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#f7b75c" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        </form>
</asp:Content>
