using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;  

namespace Project0.StoreApplication.Storage.Repositories
{
  public class OrderRepository
  {
    public List<Order> Orders { get; }

    public OrderRepository()
    {
      Orders = new List<Order>()
      {
        new Order(),
        new Order(),
        new Order()
      };
    }
  }
}