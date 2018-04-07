using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaOrderWebApplication.Models;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity;
using System.Diagnostics;
using PizzaOrderWebApplication.MyAPI;

namespace PizzaOrderWebApplication.Controllers
{
    public class CustomerOrderController : Controller
    {
        static readonly int PAGESIZE = 6;
        static readonly String CART_STRING = "mycart";

        // GET: CustomerOrder
        public ActionResult Index(int? CategoryID, int? page)
        {
            using (PizzaExpressModel context = new PizzaExpressModel())
            {
                var Categories = context.Categories.ToList();
                ViewData["Categories"] = Categories;
                Category Category = null;


                var pageindex = page ?? 1;
                var Food = context.Foods.Include(f => f.Dishes)
                    .Where(f => f.CategoryID == (CategoryID == null ? 1 : CategoryID))
                    .OrderBy(f => f.FoodID)
                    .ToPagedList(pageindex, PAGESIZE);

                Category = context.Categories.Single
                    (c => c.CategoryID == (CategoryID == null ? 1 : CategoryID));

                ViewData["Category"] = Category;
                return View(Food);
            }

        }

        [HttpGet]
        public ActionResult AddFoodToCart(String FoodID, String Size)
        {

            List<OrderDetail> mycart = (List<OrderDetail>)Session[CART_STRING];

            if (mycart == null)
            {
                mycart = new List<OrderDetail>();
            }

            OrderDetail item = new OrderDetail { FoodID = FoodID, Size = Size };

            if (mycart.Exists(o => o.FoodID == FoodID && o.Size == Size))
            {
                //plus quantity with 1
                int index = mycart.FindIndex(o => o.FoodID == item.FoodID && o.Size == item.Size);
                int oldquantity = mycart[index].Quantity;
                mycart[index].Quantity = oldquantity + 1;

                if (DiscountHelper.IsDiscountToday() && oldquantity % 2 == 1)
                {
                    //discount
                    if (Size == "S")
                    {
                        mycart[index].Discount += mycart[index].Dish.Price * 2 * 0.15;
                    }
                    else if (Size == "M")
                    {
                        mycart[index].Discount += mycart[index].Dish.Price * 2 * 0.25;
                    }
                    else if (Size == "L")
                    {
                        mycart[index].Discount += mycart[index].Dish.Price * 2 * 0.35;
                    }
                }
            }
            else
            {
                using (PizzaExpressModel context = new PizzaExpressModel())
                {
                    //create new order detail by load some info
                    //Debug.WriteLine("vao den doan lay tu DB");

                    var dish = context.Dishes.Include(d => d.Food).Single(d => d.FoodID == FoodID && d.Size == Size);
                    //dish.Food = food;
                    item.Dish = dish;
                    item.Size = Size;
                    item.Quantity = 1;
                    mycart.Add(item);
                }
            }

            Session[CART_STRING] = mycart;

            return Content("add to cart successfully, size of cart now is " + mycart.Count);

        }

        public ActionResult FoodCart()
        {
            //load cart from session
            //List<OrderDetail> mycart = (List<OrderDetail>)Session[CART_STRING];

            //if (mycart == null)
            //{
            //    mycart = new List<OrderDetail>();
            //}

            //return View(mycart);
            return Redirect("/CustomerOrders/FoodCart.aspx");
        }
    }
}