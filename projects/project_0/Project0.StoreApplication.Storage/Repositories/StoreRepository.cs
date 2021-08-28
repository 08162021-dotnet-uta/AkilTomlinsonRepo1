using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplicatetion.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    private const string _path = @"/Users/atmac/revature/akil_repo/data/stores.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {
      if (_fileAdapter.ReadFromFile<Store>(_path) == null)
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>());
      }
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Store entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });

      return true;
    }

    public bool Save(List<Store> entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, entry);

      return true;
    }
    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<Store>(_path);
    }
    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
  // public class StoreRepository
  // {
  //   public List<Store> Stores { get; }

  //   public StoreRepository()
  //   {
  //     Stores = new List<Store>()
  //     {
  //       new GroceryStore(),
  //       new ClothingStore(),
  //       new JeweleryStore()
  //     };
  //   }
  // }
}