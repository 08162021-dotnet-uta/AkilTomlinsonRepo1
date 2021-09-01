using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;

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
    /// <summary>
    /// Prints order just purchased
    /// </summary>
    /// <param name="order"></param>
    public void PrintCurrentOrder(Order order)
    {
      Console.WriteLine(order.Customer + " " + order.StoreName);
      foreach (var product in order.Products)
      {
        Console.WriteLine(product);
      }


    }
    /// <summary>
    /// Prints orders by customer
    /// </summary>
    /// <param name="customer"></param>
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
    /// <summary>
    /// Prints orders by Store
    /// </summary>
    /// <param name="store"></param>

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
    /// <summary>
    ///  View customer orders, view store orders, end program
    /// </summary>
    /// <returns></returns>
    public int OrderList()
    {
      Console.WriteLine("1 - Show Customer orders, 2 - Show Store orders, Any key - Quit");
      int orderList;
      try
      {
        orderList = int.Parse(Console.ReadLine());
      }
      catch
      {
        Log.Information("Quit without checking past orders.");
        orderList = 0;
      }

      return orderList;

    }
  }
}