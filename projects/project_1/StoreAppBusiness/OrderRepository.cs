using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dborder = StoreAppDBContext.Models.Order;

namespace StoreAppBusiness
{
  public class OrderRepository : IOrderRepository
  {
    public AkilApplicationDBContext _context;

    public OrderRepository(AkilApplicationDBContext context)
    {
      _context = context;
    }

    public void OrderList()
    {
      var orders = _context.Orders.FromSqlRaw<dborder>("SELECT * FROM Order").ToList();
      int i = 1;
      foreach (var x in orders)
      {
        Console.WriteLine("Store " + i + ": " + $"{x.Store} {x.Customer} {x.OrderProducts}");
        i++;

      }
    }

    public async Task<Order> CreateOrderAsync(string CustomerId, string StoreId)
    {
      string sqlstring = "INSERT INTO [Order] (CustomerId, StoreId, OrderDate) VALUES (" + CustomerId + "," + StoreId + "," + "'2021-09-16')";
      int orderCreated = await _context.Database.ExecuteSqlRawAsync(sqlstring);

      // if (orderCreated != 1) return 0;
      // var y = 0;
      var newOrder = await _context.Orders.FromSqlRaw("SELECT Top 1 * FROM [Order] ORDER by OrderId Desc").FirstOrDefaultAsync();
      // foreach (var x in newOrder)
      // {}


      return newOrder;
    }

    public async Task<int> PopulateOrderProductsAsync(string OrderId, string ProductId, string Quantity)
    {
      //int productInserted = await _context.Database.ExecuteSqlRawAsync("SELECT * from OrderProduct");

      int productInserted = await _context.Database.ExecuteSqlRawAsync("INSERT INTO OrderProduct (OrderId, ProductId, Quantity) VALUES ({0},{1},{2})", int.Parse(OrderId), int.Parse(ProductId), int.Parse(Quantity));

      if (productInserted != 1) return 0;

      return productInserted;

    }





    public OrderRepository()
    {
    }
  }
}
