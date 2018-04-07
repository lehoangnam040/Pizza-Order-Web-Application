using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaOrderWebApplication.Models;
using System.Data.Entity;
using PizzaOrderWebApplication.MyAPI;

namespace PizzaOrderWebApplication.Admin
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        int OrderID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["admin"];
                if (cookie != null)
                {
                    OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                    lblOrderID.Text = OrderID.ToString();
                    LoadDataToGridView(OrderID);
                }
                else
                {
                    Response.Redirect("/Admin/Login.aspx");
                }
            }
        }

        void LoadDataToGridView(int OrderID)
        {
            double total = 0;
            DataTable dt = new DataTable();

            dt.Rows.Clear();
            dt.Columns.Clear();
            dt.Columns.AddRange(
                new DataColumn[7] {
                    new DataColumn("FoodID", typeof(String)) ,
                    new DataColumn("Food", typeof(String)) ,
                    new DataColumn("Size", typeof(String)) ,
                    new DataColumn("Quantity", typeof(int)) ,
                    new DataColumn("UnitPrice", typeof(double)) ,
                    new DataColumn("Discount", typeof(double)) ,
                    new DataColumn("Price", typeof(double))
            });

            List<PizzaOrderWebApplication.Models.OrderDetail> orderDetails = DBContext.GetOrderDetailByOid(OrderID);
            foreach (PizzaOrderWebApplication.Models.OrderDetail detail in orderDetails)
            {
                double price = detail.Dish.Price * detail.Quantity - detail.Discount;
                dt.Rows.Add(detail.FoodID, detail.Dish.Food.FoodName, detail.Size, detail.Quantity, detail.Dish.Price,
                     detail.Discount, price);

                total += price;
            }

            gvDetail.AutoGenerateColumns = false;
            gvDetail.DataSource = dt;
            gvDetail.DataBind();
            lblTotal.Text = total.ToString();
        }

        protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetail.PageIndex = e.NewPageIndex;
            LoadDataToGridView(OrderID);
        }
    }
}