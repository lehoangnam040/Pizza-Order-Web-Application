using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOrderWebApplication.MyAPI
{
    public class DiscountHelper
    {
        public static bool IsDiscountToday()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool CheckPlusDiscount(int oldquantity)
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Wednesday || 
                DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return oldquantity % 2 == 1;
            } else
            {
                return false;
            }
        }

        public static bool CheckMinusDiscount(int oldquantity)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return oldquantity % 2 == 0;
            }
            else
            {
                return false;
            }
        }
    }
}