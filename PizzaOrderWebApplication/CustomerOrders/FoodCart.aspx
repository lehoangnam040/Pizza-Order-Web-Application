<%@ Page Title="Food Cart aspx" Language="C#" MasterPageFile="~/Views/Layout/WebformLayout.Master"
    AutoEventWireup="true" CodeBehind="FoodCart.aspx.cs" Inherits="PizzaOrderWebApplication.CustomerOrder.FoodCart" %>

<asp:Content ContentPlaceHolderID="Navigation" runat="server">
    <li>
        <asp:HyperLink runat="server" NavigateUrl="/Home/Index">Home</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="/CustomerOrder/Index">Menu</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="/Home/Contact">Contact</asp:HyperLink>
    </li>
</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
    <form id="form" runat="server">
        <h2><span class="label label-primary">Check the Menu you have ordered</span></h2>
        <br />
        <asp:GridView ID="gvCart" runat="server"
            CssClass="table table-responsive"
            AllowPaging="True" OnPageIndexChanging="gvCart_PageIndexChanging" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvCart_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="FoodID" DataField="FoodID" />
                <asp:BoundField HeaderText="Food" DataField="Food" />
                <asp:BoundField HeaderText="Size" DataField="Size" />
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Unit Price ($)" DataField="UnitPrice" />
                <asp:BoundField HeaderText="Discount ($)" DataField="Discount" />
                <asp:BoundField HeaderText="Price ($)" DataField="Price" />
                <asp:TemplateField Visible="true">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="+" CommandName="PlusQuantity" CssClass="btn btn-sm btn-info" />
                        <asp:Button runat="server" Text="-" CommandName="MinusQuantity" CssClass="btn btn-sm btn-info" />
                        <asp:Button runat="server" Text="Remove" CommandName="RemoveItem" CssClass="btn btn-sm btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#d9534f" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#f7b75c" ForeColor="#ffffff" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <h3 style="float: right"><span class="label label-success">Total: $<asp:Label runat="server" ID="lblTotal"></asp:Label></span></h3>
        <br />
        <h2><span class="label label-primary">And tell us your information to delivery</span></h2>
        <br />
        <div class="col-sm-8">
            <%--<asp:ValidationSummary runat="server" HeaderText="Check your informations: " ForeColor="Red" />--%>
            <div class="form-group clearfix">
                <label class="control-label col-sm-4 text-primary">Your name: </label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="tbxName" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxName"
                        ErrorMessage="Your name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group clearfix">
                <label class="control-label col-sm-4 text-primary">Your address: </label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="tbxAddress" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxAddress"
                        ErrorMessage="Your address is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group clearfix">
                <label class="control-label col-sm-4 text-primary">Your phone: </label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="tbxPhone" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="tbxPhone"
                         ErrorMessage="Must enter string with 10 - 14 numbers" ForeColor="Red" 
                        ValidationExpression="\d{10,14}"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPhone"
                         ErrorMessage="Your phone is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group clearfix">
                <label class="control-label col-sm-4 text-primary">Delivery time: </label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="tbxShipdate" TextMode="DateTimeLocal" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPhone"
                         ErrorMessage="Delivery time is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group clearfix">
                <label class="control-label col-sm-4 text-primary">Any Note ? </label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="tbxNote" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></td> 
                </div>
            </div>
        </div>
        <p class="clearfix"></p>
        <p class="text-center">
            <asp:Button runat="server" ID="btnOrder" Text="Order Now"
                CssClass="btn btn-lg btn-info" OnClick="btnOrder_Click" />
        </p>
    </form>

</asp:Content>
