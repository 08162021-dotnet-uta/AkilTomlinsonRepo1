using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dbstore = StoreAppDBContext.Models.Store;

namespace StoreAppBusiness
{
  public class StoreRepository : IStoreRepository
  {
    public AkilApplicationDBContext _context = new AkilApplicationDBContext();

    public StoreRepository(AkilApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<List<Store>> StoreListAsync()
    {
      List<Store> stores = await _context.Stores.FromSqlRaw<dbstore>("SELECT * FROM Store").ToListAsync();
      List<Store> stores1 = new List<Store>();
      foreach (var x in stores)
      {
        stores1.Add(x);

      }
      return stores1;
    }

    public void StoreOrderList()
    {
      string statement = "SELECT * FROM ViewStoreOrders";
      var storeOrder = _context.ViewStoreOrders.FromSqlRaw(statement).ToList();

      foreach (var x in storeOrder)
      {
        Console.WriteLine($"{x.FirstName} {x.OrderId}");

      }
    }

    public async Task<List<ViewStoreOrder>> StoreOrderListAsync(string store)
    {
      string statement = $"SELECT * FROM ViewStoreOrders WHERE StoreId={store}";
      List<ViewStoreOrder> storeOrder = await _context.ViewStoreOrders.FromSqlRaw(statement).ToListAsync();
      List<ViewStoreOrder> storeOrder1 = new List<ViewStoreOrder>();
      foreach (var x in storeOrder)
      {
        storeOrder1.Add(x);
      }
      return storeOrder1;
    }





    public void StoreOrders()
    {

    }







    public StoreRepository()
    {
    }
  }
}
