using System.Collections.Generic;
using Project0.StoreApplicatetion.Storage.Adapters;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private const string _path = @"/Users/atmac/revature/akil_repo/data/products.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public ProductRepository()
    {
      if (_fileAdapter.ReadFromFile<Product>(_path) == null)
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>());
      }
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Product entry)
    {
      _fileAdapter.WriteToFile<Product>(_path, new List<Product> { entry });

      return true;
    }

    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<Product>(_path);
    }

    public Product Update()
    {
      throw new System.NotImplementedException();
    }

    // public List<Product> Products { get; set; }

    // public ProductRepository()
    // {
    //   Product p;
    //   Products = new List<Product>();

    //   p = new Product();
    //   p.Name = "T-Shirt";
    //   p.Category = "Clothing";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Hoodie";
    //   p.Category = "Clothing";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Jeans";
    //   p.Category = "Clothing";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Eggs";
    //   p.Category = "Grocery";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Bacon";
    //   p.Category = "Grocery";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Cereal";
    //   p.Category = "Grocery";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Necklace";
    //   p.Category = "Jewelery";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Ring";
    //   p.Category = "Jewelery";
    //   Products.Add(p);

    //   p = new Product();
    //   p.Name = "Bracelet";
    //   p.Category = "Jewelery";
    //   Products.Add(p);




    //   // Products = new List<Product>()
    //   // {
    //   //   new Product(),
    //   //   new Product(),
    //   //   new Product()
    //   // };
    // }
  }
}