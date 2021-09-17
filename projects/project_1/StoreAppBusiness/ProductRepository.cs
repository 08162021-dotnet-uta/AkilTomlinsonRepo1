using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dbprod = StoreAppDBContext.Models.Product;

namespace StoreAppBusiness
{
  public class ProductRepository : IProductRepository
  {
    public AkilApplicationDBContext _context;

    public ProductRepository(AkilApplicationDBContext context)
    {
      _context = context;
    }

    public void ProductList()
    {
      var products = _context.Products.FromSqlRaw<dbprod>("SELECT * FROM Product").ToList();
      int i = 1;
      foreach (var x in products)
      {
        Console.WriteLine("Product " + i + ": " + $"{x.ProductName} {x.ProductDescription} {x.ProductPrice}");
        i++;

      }
    }

    public async Task<List<ViewStoreProduct>> StoreProductListAsync(string store)
    {
      string statement = $"SELECT * FROM ViewStoreProducts WHERE StoreId={store}";
      List<ViewStoreProduct> storeProducts = await _context.ViewStoreProducts.FromSqlRaw(statement).ToListAsync();
      List<ViewStoreProduct> storeProducts1 = new List<ViewStoreProduct>();
      foreach (var x in storeProducts)
      {
        storeProducts1.Add(x);
      }
      return storeProducts1;
    }

    public async Task<ViewStoreProduct> ProductDataAsync(string productId)
    {
      string statement = $"SELECT * FROM ViewStoreProducts WHERE ProductId={productId}";
      ViewStoreProduct productData = await _context.ViewStoreProducts.FromSqlRaw(statement).FirstOrDefaultAsync();

      return productData;
    }





    public ProductRepository()
    {
    }
  }
}
