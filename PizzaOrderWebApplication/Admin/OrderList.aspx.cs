using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaOrderWebApplication.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using PizzaOrderWebApplication.MyAPI;

namespace PizzaOrderWebApplication.Admin
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["admin"];
                if (cookie != null)
                {
                    GetDataToGridView();
                }
                else
                {
                    Response.Redirect("/Admin/Login.aspx");
                }
            }

        }

        void GetDataToGridView()
        {
            List<PizzaOrderWebApplication.Models.Order> listOd = DBContext.GetAllOrders();
            gvOrders.DataSource = listOd;
            gvOrders.DataBind();
        }

        protected void timerUpdate_Tick(object sender, EventArgs e)
        {
            GetDataToGridView();
        }
        
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrderDetail")
            {
                //get order id
                int OrderID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("~/Admin/OrderDetail.aspx?OrderID=" + OrderID);
            }
        }
    }
}