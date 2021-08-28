using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;


namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program class
  /// </summary>
  class Program
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>

    static void Main(string[] args)
    {
      // Should log to file where the user goes in the program
      // Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
      // List<Store> populatedStores = _storeSingleton.PopulateStores();
      // _storeSingleton.SaveStores(populatedStores);

      InitStores();
      PrintCustomerId();

      System.Console.WriteLine("Welcome back: " + CustomerId());

      PrintAllStoreLocations();
      var selectedStore = SelectAStore();
      System.Console.WriteLine("You have selected the: " + selectedStore);


      PrintStoreProducts(selectedStore, _storeSingleton.Stores);
      System.Console.WriteLine("You have added " + SelectAProduct(selectedStore) + " to the order.");
      // HelloSQL();
    }

    static void PrintAllStoreLocations()
    {
      Log.Information("Print Store");

      var storeRepository = new StoreRepository();
      int i = 1;

      foreach (var store in _storeSingleton.Stores)
      {
        System.Console.WriteLine(i + "-" + store);
        i++;
      }
    }

    static void PrintCustomerId()
    {
      Log.Information("Print Id");

      var customerRepository = new CustomerRepository();
      int i = 1;

      // foreach (var id in customerRepository.Customers)
      foreach (var id in _customerSingleton.Customers)
      {
        System.Console.WriteLine(i + "-" + id);
        i++;
      }
    }
    static void PrintStoreProducts(Store x, List<Store> z)
    {

      Console.WriteLine("Products for sale: ");
      var storesSigleton = _storeSingleton;
      foreach (var y in z)
      {
        if (x.Name == y.Name)
        {
          storesSigleton.PrintStoreProducts(y);
        }
      }

      // var productRepository = new ProductRepository();

      // foreach (var product in productRepository.Products)
      // {
      //   System.Console.WriteLine(product);

      // }
    }

    static Store SelectAStore()
    {
      var location = _storeSingleton.Stores;

      Console.WriteLine("Select a Store: ");

      var option = int.Parse(Console.ReadLine());
      var store = location[option - 1];

      return store;
    }
    static Product SelectAProduct(Store selectedStoreX)
    {
      var product = selectedStoreX.Products;

      Console.WriteLine("Select a Product: ");

      var option = int.Parse(Console.ReadLine());
      var selection = product[option - 1];

      return selection;
      // does not return as expected
    }

    static Customer CustomerId()
    {
      //var customer = new CustomerRepository().Customers;
      var customer = _customerSingleton.Customers;

      Console.WriteLine("Select a Customer Id: ");

      var option = int.Parse(Console.ReadLine());
      var id = customer[option - 1];

      return id;
    }

    static void InitStores()
    {
      var populate = _storeSingleton;
      populate.PopulateStores();
    }
    /// <summary>
    /// Testing db connection
    /// </summary>
    private static void HelloSQL()
    {
      var def = new DemoEF();

      foreach (var item in def.GetCustomers())
      {
        Console.WriteLine(item);
      }

    }

  }
}
