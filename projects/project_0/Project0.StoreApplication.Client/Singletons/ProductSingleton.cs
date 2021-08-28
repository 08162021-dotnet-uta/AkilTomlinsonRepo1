using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{

  public class ProductSingleton
  {
    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepository = new ProductRepository();
    public List<Product> Products { get; set; }

    public static ProductSingleton Instance
    {
      get
      {
        if (_productSingleton == null)
        {
          _productSingleton = new ProductSingleton();
        }

        return _productSingleton;
      }
    }
    private ProductSingleton()
    {
      Products = _productRepository.Select();
    }

    public void Add(Product product)
    {
      _productRepository.Insert(product);
      Products = _productRepository.Select();
    }
  }
}