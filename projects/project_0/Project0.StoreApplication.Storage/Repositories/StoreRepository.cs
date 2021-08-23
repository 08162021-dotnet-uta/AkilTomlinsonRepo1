using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    public List<Store> Stores { get; }

    public StoreRepository()
    {
      Stores = new List<Store>()
      {
        new GroceryStore(),
        new GroceryStore(),
        new GroceryStore()
      };
    }
  }
}