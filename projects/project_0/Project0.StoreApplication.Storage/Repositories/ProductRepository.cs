using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
    public List<Product> Products { get; }

    public ProductRepository()
    {
      Products = new List<Product>()
      {
        new Product(),
        new Product(),
        new Product()
      };
    }
  }
}