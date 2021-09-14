using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreAppDBContext.Models;
using dborder = StoreAppDBContext.Models.Order;

namespace StoreAppBusiness
{
    public class OrderRepository
    {
        public AkilApplicationDBContext context = new AkilApplicationDBContext();

        public void OrderList()
        {
            var orders = context.Orders.FromSqlRaw<dborder>("SELECT * FROM Order").ToList();
            int i = 1;
            foreach (var x in orders)
            {
                Console.WriteLine("Store " + i + ": " + $"{x.Store} {x.Customer} {x.OrderProducts}");
                i++;

            }
        }





        public OrderRepository()
        {
        }
    }
}
