using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreAppDBContext.Models;

namespace StoreAppBusiness.Interfaces
{
  public interface IOrderRepository
  {
    Task<int> PopulateOrderProductsAsync(string OrderId, string ProductId, string Quantity);
    Task<Order> CreateOrderAsync(string CustomerId, string StoreId);
    void OrderList();
  }
}
