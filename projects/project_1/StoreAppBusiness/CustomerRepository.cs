using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dbcust = StoreAppDBContext.Models.Customer;

namespace StoreAppBusiness
{
  public class CustomerRepository : ICustomerRepository
  {
    public AkilApplicationDBContext _context;

    public CustomerRepository(AkilApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<List<Customer>> CustomerListAsync()
    {
      List<dbcust> customers = await _context.Customers.FromSqlRaw<dbcust>("SELECT * FROM Customer").ToListAsync();
      List<dbcust> cust = new List<dbcust>();


      foreach (Customer x in customers)
      {
        cust.Add(x);
      }
      return cust;
    }

    public void CustOrderList()
    {
      string statement = "SELECT * FROM ViewStoreOrders";
      var storeOrder = _context.ViewStoreOrders.FromSqlRaw(statement).ToList();

      foreach (var x in storeOrder)
      {
        Console.WriteLine($"{x.OrderId} {x.FirstName} {x.ProductName} {x.ProductPrice} {x.Quantity}");

      }
    }

    public async Task<List<ViewStoreOrder>> CustOrderListAsync(string customer)
    {
      string statement = $"SELECT * FROM ViewStoreOrders WHERE CustomerId={customer}";
      List<ViewStoreOrder> custOrder = await _context.ViewStoreOrders.FromSqlRaw(statement).ToListAsync();
      List<ViewStoreOrder> custOrder1 = new List<ViewStoreOrder>();
      foreach (var x in custOrder)
      {
        custOrder1.Add(x);
      }
      return custOrder1;
    }

    public async Task<dbcust> LoginCustomerAsync(Customer customer)
    {
      // dbcust logincust = new dbcust();
      customer = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer WHERE FirstName = {0} and LastName = {1}", customer.FirstName, customer.LastName).FirstOrDefaultAsync();

      if (customer == null) return null;

      return customer;
    }

    public async Task<Customer> RegisterCustomerAsync(Customer cust)
    {

      int customer1 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customer (FirstName, LastName) VALUES ({0},{1})", cust.FirstName, cust.LastName);

      if (customer1 != 1) return null;

      return await LoginCustomerAsync(cust);
    }




    public CustomerRepository()
    {
    }
  }
}
