using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreAppDBContext.Models;
using dbstore = StoreAppDBContext.Models.Store;

namespace StoreAppBusiness
{
    public class StoreRepository
    {
        public AkilApplicationDBContext context = new AkilApplicationDBContext();

        public void StoreList()
        {
            var stores = context.Stores.FromSqlRaw<dbstore>("SELECT * FROM Store").ToList();
           
            foreach (var x in stores)
            {
                Console.WriteLine("Store " + $"{x.StoreId}" + ": " + $"{x.StoreName}");

            }
        }

        public void StoreOrderList()
        {
            string statement = "SELECT * FROM ViewStoreOrders";
            var storeOrder = context.ViewStoreOrders.FromSqlRaw(statement).ToList();

            foreach (var x in storeOrder)
            {
                Console.WriteLine($"{x.FirstName} {x.OrderId}");

            }
        }

        public void StoreOrderList(string store)
        {
            string statement = $"SELECT * FROM ViewStoreOrders WHERE StoreId={store}";
            var storeOrder = context.ViewStoreOrders.FromSqlRaw(statement).ToList();

            foreach (var x in storeOrder)
            {
                Console.WriteLine($"{x.OrderId} {x.FirstName} {x.ProductName} {x.ProductPrice} {x.Quantity}");

            }
        }





        public void StoreOrders()
        {

        }







        public StoreRepository()
        {
        }
    }
}
