using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaOrderWebApplication.MyAPI;

namespace PizzaOrderWebApplication.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String email = tbxEmail.Text;
            String password = tbxPassword.Text;


            if(DBContext.GetAdminByUser(email, password))
            {
                //tao cookie co ten la admin
                HttpCookie cookie = new HttpCookie("admin");
                //them cookie email va set value cho cookie email
                cookie["email"] = email;
                cookie.Expires.Add(new TimeSpan(0, 10, 0));
                Response.Cookies.Add(cookie);
                Response.Redirect("/Admin/OrderList.aspx");
            } else
            {
                lblNotify.Text = "Check your email or your password";
            }
        }
    }
}