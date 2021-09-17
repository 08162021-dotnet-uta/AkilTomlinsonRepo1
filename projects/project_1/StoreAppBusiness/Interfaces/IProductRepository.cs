using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreAppDBContext.Models;

namespace StoreAppBusiness.Interfaces
{
  public interface IProductRepository
  {
    void ProductList();
    Task<List<ViewStoreProduct>> StoreProductListAsync(string store);

    Task<ViewStoreProduct> ProductDataAsync(string productId);
  }
}
