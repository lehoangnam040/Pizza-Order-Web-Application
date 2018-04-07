using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaOrderWebApplication.Models;
using System.Data.SqlClient;

namespace PizzaOrderWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetContact(String name, String email, String phone, String message)
        {
            using (PizzaExpressModel context = new PizzaExpressModel())
            {
                object[] contactparams = new object[]
                {
                    new SqlParameter("@name", name),
                    new SqlParameter("@email", email),
                    new SqlParameter("@phone", phone),
                    new SqlParameter("@message", message)
                };
                context.Database.ExecuteSqlCommand("insert into Contact values(@name, @email, @phone, @message)", contactparams);
            }
            return Redirect("/Home/");
        }
    }
}