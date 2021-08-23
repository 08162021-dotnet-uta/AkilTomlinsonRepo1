using System;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;

namespace Project0.StoreApplication.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

      PrintAllStoreLocations();

      System.Console.WriteLine(SelectAStore());

      PrintAllProducts();
    }

    static void PrintAllStoreLocations()
    {
      Log.Information("Print Store");

      var storeRepository = new StoreRepository();
      int i = 1;

      foreach (var store in storeRepository.Stores)
      {
        System.Console.WriteLine(i + "-" + store);
        i++;
      }
    }
    static void PrintAllProducts()
    {
      var productRepository = new ProductRepository();

      foreach (var product in productRepository.Products)
      {
        System.Console.WriteLine(product);

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
