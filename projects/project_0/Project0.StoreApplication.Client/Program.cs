using System;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      PrintAllStoreLocations();

      System.Console.WriteLine(SelectAStore());
    }

    static void PrintAllStoreLocations()
    {
      var storeRepository = new StoreRepository();
      int i = 1;

      foreach (var store in storeRepository.Stores)
      {
        System.Console.WriteLine(i + "-" + store);
        i++;
      }
    }

    static Store SelectAStore()
    {
      var location = new StoreRepository().Stores;

      Console.WriteLine("Select a Store: ");

      var option = int.Parse(Console.ReadLine());
      var store = location[option - 1];

      return store;
    }
  }
}
