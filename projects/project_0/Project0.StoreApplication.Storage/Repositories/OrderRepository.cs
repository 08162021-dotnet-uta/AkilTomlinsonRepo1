using System.Collections.Generic;
using Project0.StoreApplicatetion.Storage.Adapters;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class OrderRepository : IRepository<Order>
  {
    private const string _path = @"/Users/atmac/revature/akil_repo/data/orders.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public OrderRepository()
    {
      if (_fileAdapter.ReadFromFile<Order>(_path) == null)
      {
        _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
      }
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Order entry)
    {
      _fileAdapter.WriteToFile<Order>(_path, new List<Order> { entry });

      return true;
    }

    public bool Save(List<Order> entry)
    {
      _fileAdapter.WriteToFile<Order>(_path, entry);

      return true;
    }
    public List<Order> Select()
    {
      return _fileAdapter.ReadFromFile<Order>(_path);
    }
    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }


  // public class OrderRepository
  // {
  //   public List<Order> Orders { get; }

  //   public OrderRepository()
  //   {
  //     Orders = new List<Order>()
  //     {
  //       new Order(),
  //       new Order(),
  //       new Order()
  //     };
  //   }
  // }
}