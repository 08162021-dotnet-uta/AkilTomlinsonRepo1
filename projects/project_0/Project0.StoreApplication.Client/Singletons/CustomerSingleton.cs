using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{

  public class CustomerSingleton
  {
    private static CustomerSingleton _customerSingleton;
    private static readonly CustomerRepository _customerRepository = new CustomerRepository();
    public List<Customer> Customers { get; set; }

    public static CustomerSingleton Instance
    {
      get
      {
        if (_customerSingleton == null)
        {
          _customerSingleton = new CustomerSingleton();
        }

        return _customerSingleton;
      }
    }
    private CustomerSingleton()
    {
      Customers = _customerRepository.Select();
    }

    public void Add(Customer customer)
    {
      _customerRepository.Insert(customer);
      Customers = _customerRepository.Select();
    }

    public void PrintCustomerId()
    {
      // var customerRepository = new CustomerRepository();
      int i = 1;

      // foreach (var id in customerRepository.Customers)
      foreach (var id in _customerSingleton.Customers)
      {
        System.Console.WriteLine("Customer ID: " + i + " - " + id);
        i++;
      }
      Console.WriteLine();
    }
    // private CustomerSingleton()
    // {
    //   Cusomters = _customerRepository.Get();
    // }
  }
}