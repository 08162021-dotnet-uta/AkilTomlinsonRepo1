using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreAppDBContext.Models;
using dbcust = StoreAppDBContext.Models.Customer;

namespace StoreAppBusiness
{
    public class CustomerRepository
    {
        public AkilApplicationDBContext context = new AkilApplicationDBContext();

        public void CustomerList()
        {
            var customers = context.Customers.FromSqlRaw<dbcust>("SELECT * FROM Customer").ToList();
            foreach (var x in customers)
            {
                Console.WriteLine("Customer " + $"{x.CustomerId}" + ": " + $"{x.FirstName} {x.LastName}");
               

            }
        }

        public void CustOrderList(string customer)
        {
            string statement = $"SELECT * FROM ViewStoreOrders WHERE CustomerId={customer}";
            var storeOrder = context.ViewStoreOrders.FromSqlRaw(statement).ToList();

            foreach (var x in storeOrder)
            {
                Console.WriteLine($"{x.OrderId} {x.FirstName} {x.ProductName} {x.ProductPrice} {x.Quantity}");

            }
        }





        public CustomerRepository()
        {
        }
    }
}
