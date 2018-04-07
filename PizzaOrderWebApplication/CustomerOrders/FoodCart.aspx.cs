using PizzaOrderWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaOrderWebApplication.MyAPI;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PizzaOrderWebApplication.CustomerOrder
{
    public partial class FoodCart : System.Web.UI.Page
    {
        static readonly String CART_STRING = "mycart";

        DataTable dtCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataToGridView();
                tbxShipdate.Text = DateTime.Now.AddHours(2).ToString("yyyy-MM-dd HH:mm").Replace(' ', 'T');
            }
        }

        void loadDataToGridView()
        {
            List<OrderDetail> mycart = (List<OrderDetail>)Session[CART_STRING];

            if (mycart == null)
            {
                btnOrder.CssClass += " disabled";
            }
            else
            {
                double total = 0;

                dtCart = new DataTable();
                dtCart.Rows.Clear();
                dtCart.Columns.Clear();
                dtCart.Columns.AddRange(
                    new DataColumn[7] {
                    new DataColumn("FoodID", typeof(String)) ,
                    new DataColumn("Food", typeof(String)) ,
                    new DataColumn("Size", typeof(String)) ,
                    new DataColumn("Quantity", typeof(int)) ,
                    new DataColumn("UnitPrice", typeof(double)) ,
                    new DataColumn("Discount", typeof(double)) ,
                    new DataColumn("Price", typeof(double))
                });

                foreach (var o in mycart)
                {
                    double price = o.Dish.Price * o.Quantity - o.Discount;
                    dtCart.Rows.Add(o.FoodID, o.Dish.Food.FoodName, o.Size, o.Quantity, o.Dish.Price,
                         o.Discount, price);

                    total += price;
                }
                gvCart.AutoGenerateColumns = false;
                gvCart.DataSource = dtCart;
                gvCart.DataBind();
                lblTotal.Text = total.ToString();
            }
        }


        protected void btnOrder_Click(object sender, EventArgs e)
        {
            List<OrderDetail> mycart = (List<OrderDetail>)Session[CART_STRING];

            if (mycart != null)
            {
                //add order and order detail to database
                String name = tbxName.Text.Trim();
                String address = tbxAddress.Text.Trim();
                String phone = tbxPhone.Text.Trim();
                String note = tbxNote.Text.Trim();
                DateTime shippedDate = Convert.ToDateTime(tbxShipdate.Text);

                using (PizzaExpressModel context = new PizzaExpressModel())
                {
                    object[] dbparams = new object[]
                    {
                        new SqlParameter("@name", name),
                        new SqlParameter("@address", address),
                        new SqlParameter("@phone", phone),
                        new SqlParameter("@note", note),
                        new SqlParameter("@orderDate", DateTime.Now),
                        new SqlParameter("@shippedDate", shippedDate)
                    };

                    int OrderID = context.Database.SqlQuery<int>("insert into Orders(CustomerName, CustomerAddress, " +
                        "Phone, OrderDate, ShippedDate, Note) output inserted.OrderID values(@name, @address, @phone, @orderDate, @shippedDate, @note)", dbparams).Single();

                    foreach (var od in mycart)
                    {
                        object[] odparams = new object[]
                        {
                            new SqlParameter("@OrderID", OrderID),
                            new SqlParameter("@FoodID", od.FoodID),
                            new SqlParameter("@Size", od.Size),
                            new SqlParameter("@Discount", od.Discount),
                            new SqlParameter("@Quantity", od.Quantity)
                        };
                        var x = context.Database.ExecuteSqlCommand("insert into OrderDetail values(@OrderID, @FoodID, @Size, @Discount, @Quantity)", odparams);

                    }
                    mycart.Clear();
                    Session[CART_STRING] = mycart;
                    Response.Redirect("/Home/Index");
                }
            }
        }

        protected void gvCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCart.PageIndex = e.NewPageIndex;
            loadDataToGridView();
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                List<OrderDetail> mycart = (List<OrderDetail>)Session[CART_STRING];
                int rowindex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;

                String FoodID = gvCart.Rows[rowindex].Cells[0].Text;
                String Size = gvCart.Rows[rowindex].Cells[2].Text;
                int oldquantity = Convert.ToInt32(gvCart.Rows[rowindex].Cells[3].Text);

                int odindex = mycart.FindIndex(o => o.FoodID == FoodID && o.Size == Size);

                if (e.CommandName == "PlusQuantity" && oldquantity < 10)
                {
                    mycart[odindex].Quantity = oldquantity + 1;

                    if (DiscountHelper.IsDiscountToday() && oldquantity % 2 == 1)
                    {
                        //discount
                        if (Size == "S")
                        {
                            mycart[odindex].Discount += mycart[odindex].Dish.Price * 2 * 0.15;
                        }
                        else if (Size == "M")
                        {
                            mycart[odindex].Discount += mycart[odindex].Dish.Price * 2 * 0.25;
                        }
                        else if (Size == "L")
                        {
                            mycart[odindex].Discount += mycart[odindex].Dish.Price * 2 * 0.35;
                        }
                    }
                }
                else if (e.CommandName == "MinusQuantity" && oldquantity > 1)
                {
                    mycart[odindex].Quantity = oldquantity - 1;

                    if (DiscountHelper.IsDiscountToday() && oldquantity % 2 == 0)
                    {
                        //reduce discount
                        if (Size == "S")
                        {
                            mycart[odindex].Discount -= mycart[odindex].Dish.Price * 2 * 0.15;
                        }
                        else if (Size == "M")
                        {
                            mycart[odindex].Discount -= mycart[odindex].Dish.Price * 2 * 0.25;
                        }
                        else if (Size == "L")
                        {
                            mycart[odindex].Discount -= mycart[odindex].Dish.Price * 2 * 0.35;
                        }
                    }
                }
                else if (e.CommandName == "RemoveItem")
                {
                    mycart.RemoveAt(odindex);
                }
                loadDataToGridView();
            }

        }
    }
}