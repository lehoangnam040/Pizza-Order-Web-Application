<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/Admin/AdminLayout.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PizzaOrderWebApplication.Admin.Login" %>

<asp:Content ID="Navigation" ContentPlaceHolderID="Navigation" runat="server">
    <%--<li class="disabled">
        <asp:hyperlink runat="server" navigateurl="~/Admin/OrderList.aspx">Orders</asp:hyperlink>
    </li>
    <li class="disabled">
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Contact.aspx">Contact</asp:HyperLink>
    </li>
    <li class="disabled">
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Logout.aspx">Log out</asp:HyperLink>
    </li>--%>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <h2><span class="label label-info">Login</span></h2>
    <br />
    <form id="loginform" runat="server" class="col-sm-6">
        <div class="form-group">
            <label for="username">Email:</label>
            <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>        
        </div>
        <div class="form-group">
            <label for="password">Password:</label>
            <asp:TextBox runat="server" ID="tbxPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>    
        </div>
        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-default" Text="Login" OnClick="btnLogin_Click"/>
        <br />
        <asp:Label runat="server" ID="lblNotify"></asp:Label>
    </form>
</asp:Content>
