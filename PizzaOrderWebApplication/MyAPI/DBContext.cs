using PizzaOrderWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaOrderWebApplication.MyAPI
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["PizzaDB"].ToString();
            SqlConnection conn = new SqlConnection(strConnection);
            return conn;
        }

        static public List<Order> GetAllOrders()
        {
            List<Order> list = new List<Order>();
            SqlConnection connection = GetConnection();

            string query = @"SELECT [OrderID]
                              ,[OrderDate]
                              ,[ShippedDate]
                              ,[CustomerName]
                              ,[CustomerAddress]
                              ,[Phone]
                              ,[Note]
                          FROM [dbo].[Orders]";

            SqlCommand command = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Order o = new Order
                {
                    OrderID = Convert.ToInt32(dr["OrderID"]),
                    OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                    ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                    CustomerName = dr["CustomerName"].ToString(),
                    CustomerAddress = dr["CustomerAddress"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Note = dr["Note"].ToString()
                };
                //int OrderId = Convert.ToInt32(dr["OrderID"]);
                //DateTime OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                //DateTime ShippedDate = Convert.ToDateTime(dr["ShippedDate"]);
                //string CustomerName = dr["CustomerName"].ToString();
                //string CustomerAddress = dr["CustomerAddress"].ToString();
                //string Phone = dr["Phone"].ToString();
                //string Note = dr["Note"].ToString();
                //Order o = new Order(OrderId, OrderDate, ShippedDate, CustomerName, CustomerAddress, Phone, Note);
                list.Add(o);
            }
            return list;
        }

        static public List<OrderDetail> GetOrderDetailByOid(int odID)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            SqlConnection connection = GetConnection();

            string query = @"SELECT [OrderID]
                                  ,od.[FoodID]
                                  ,od.[Size]
                                  ,[Discount]
                                  ,[Quantity]
								  ,di.Price
								  ,fo.FoodName
                              FROM [dbo].[OrderDetail] od, [dbo].[Dish] di, [dbo].[Food] fo
                              WHERE od.FoodID = di.FoodID AND od.Size = di.Size
							        AND di.FoodID = fo.FoodID
							        AND [OrderID] = @odID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@odID", odID));
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Food food = new Food
                {
                    FoodName = dr["FoodName"].ToString()
                };
                Dish dish = new Dish
                {
                    Food = food,
                    Price = Convert.ToDouble(dr["Price"])
                };
                OrderDetail o = new OrderDetail
                {
                    OrderID = Convert.ToInt32(dr["OrderID"]),
                    FoodID = dr["FoodID"].ToString(),
                    Size = dr["Size"].ToString(),
                    Discount = Convert.ToDouble(dr["Discount"]),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Dish = dish
                };

                list.Add(o);
            }
            return list;
        }

        static public List<Contact> GetAllContact()
        {
            List<Contact> list = new List<Contact>();
            SqlConnection connection = GetConnection();

            string query = @"SELECT [ContactName]
                                  ,[Email]
                                  ,[Phone]
                                  ,[ContactMessage]
                              FROM [dbo].[Contact]";

            SqlCommand command = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Contact o = new Contact
                {
                    ContactName = dr["ContactName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    ContactMessage = dr["ContactMessage"].ToString()
                };
                list.Add(o);
            }
            return list;
        }


        static public bool GetAdminByUser(string user, string pass)
        {
            Account ad = new Account();
            SqlConnection connection = GetConnection();

            string query = @"SELECT [User]
                                      ,[Password]
                                  FROM [dbo].[Account]
                                  where [User] = @user and password = @pass";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@user", user));
            command.Parameters.Add(new SqlParameter("@pass", pass));
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
    }
}