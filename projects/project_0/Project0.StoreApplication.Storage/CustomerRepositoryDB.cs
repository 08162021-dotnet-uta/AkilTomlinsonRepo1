using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage
{
  public class CustomerRepositoryDB
  {
    private readonly DataAdapter _dataAdapter = new DataAdapter();

    public List<Customer> GetCustomers()
    {
      return _dataAdapter.Customers.FromSqlRaw("select * from Customer.Customer").ToList();
    }


    public void SetCustomer(Customer customer)
    {
      // _da.Customers.FromSqlRaw("insert into Customer.Customer(Name) values (Jack)", customer.Name);
      _dataAdapter.Database.ExecuteSqlRaw("insert into Customer.Customer(Name) values (Jack)", customer.Name);
      // _da.SaveChanges();
    }
  }
}