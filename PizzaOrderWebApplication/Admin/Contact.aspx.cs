using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaOrderWebApplication.Models;
using PizzaOrderWebApplication.MyAPI;


namespace PizzaOrderWebApplication.Admin
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["admin"];
                if (cookie != null)
                {
                    List<PizzaOrderWebApplication.Models.Contact> list = DBContext.GetAllContact();
                    gvContact.DataSource = list;
                    gvContact.DataBind();

                }
                else
                {
                    Response.Redirect("/Admin/Login.aspx");
                }

            }
        }
    }
}