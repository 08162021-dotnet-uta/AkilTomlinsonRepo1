using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    public List<Store> Stores { get; set; }

    public StoreRepository()
    {
      Stores = new List<Store>()
      {
        new Store(){Name = "Location1"},
        new Store(){Name = "Location2"},
        new Store(){Name = "Location3"}
      };
    }
  }
}