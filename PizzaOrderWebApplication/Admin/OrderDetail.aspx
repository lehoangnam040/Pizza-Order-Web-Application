<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="PizzaOrderWebApplication.Admin.OrderDetail" %>
<asp:Content ContentPlaceHolderID="Navigation" runat="server">
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/OrderList.aspx">Orders</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Contact.aspx">Contact</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Logout.aspx">Log out</asp:HyperLink>
    </li>
</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
    <h2><span class="label label-info">Detail of order with ID: <asp:Label runat="server" ID="lblOrderID"></asp:Label></span></h2>
    <br />
    <form id="form" runat="server">
        <asp:GridView runat="server" ID="gvDetail" CssClass="table table-responsive" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvDetail_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="FoodID" DataField="FoodID" />
                <asp:BoundField HeaderText="Food" DataField="Food" />
                <asp:BoundField HeaderText="Size" DataField="Size" />
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Unit Price ($)" DataField="UnitPrice" />
                <asp:BoundField HeaderText="Discount ($)" DataField="Discount" />
                <asp:BoundField HeaderText="Price ($)" DataField="Price" />
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
        <h3 style="float: right"><span class="label label-success">Total: $<asp:Label runat="server" ID="lblTotal"></asp:Label></span></h3>
        <br />
    </form>
</asp:Content>
