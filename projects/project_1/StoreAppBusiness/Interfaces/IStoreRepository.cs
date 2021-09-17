using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreAppDBContext.Models;

namespace StoreAppBusiness.Interfaces
{
  public interface IStoreRepository
  {
    Task<List<Store>> StoreListAsync();
    void StoreOrderList();
    Task<List<ViewStoreOrder>> StoreOrderListAsync(string store);
  }
}
