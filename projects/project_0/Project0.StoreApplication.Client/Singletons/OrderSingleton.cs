using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{

  public class OrderSingleton
  {
    private static OrderSingleton _orderSingleton;
    private static readonly OrderRepository _orderRepository = new OrderRepository();
    public List<Order> Orders { get; set; }

    public static OrderSingleton Instance
    {
      get
      {
        if (_orderSingleton == null)
        {
          _orderSingleton = new OrderSingleton();
        }

        return _orderSingleton;
      }
    }
    private OrderSingleton()
    {
      Orders = _orderRepository.Select();
    }

    public void Add(Order order)
    {
      Orders.Add(order);

    }
    public void SaveOrders()
    {
      _orderRepository.Save(Orders);
      Orders = _orderRepository.Select();
    }

    public void PrintCurrentOrder(Order order)
    {
      Console.WriteLine(order.Customer + " " + order.StoreName);
      foreach (var product in order.Products)
      {
        Console.WriteLine(product);
      }


    }
    public void PrintOrders(Customer customer)
    {
      foreach (var order in Orders)
      {
        if (customer.Name == order.Customer.Name)
        {
          Console.WriteLine(order.Customer + " " + order.StoreName);
          foreach (var product in order.Products)
          {
            Console.WriteLine(product);
          }
          Console.WriteLine();
        }
      }

    }

    public void PrintOrders(Store store)
    {
      foreach (var order in Orders)
      {
        if (store.Name == order.StoreName)
        {
          Console.WriteLine(order.Customer + " " + order.StoreName);
          foreach (var product in order.Products)
          {
            Console.WriteLine(product);
          }
        }
      }

    }
  }
}