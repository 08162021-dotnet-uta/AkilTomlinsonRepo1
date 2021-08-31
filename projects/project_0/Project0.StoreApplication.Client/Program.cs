using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
  public class Program
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;

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

      Customer selectedCustomer; //Current customer
      Store selectedStore; //Current store with products
      Order currentOrder = new Order(); //Current order
      Product selectedProduct;

      InitStores();
      PrintCustomerId();

      selectedCustomer = SelectCustomer();
      System.Console.WriteLine("Welcome back: " + selectedCustomer);
      Console.WriteLine();
      PrintAllStoreLocations();
      Console.WriteLine();

      selectedStore = SelectAStore();
      System.Console.WriteLine("You have selected the: " + selectedStore);
      Console.WriteLine();

      PrintStoreProducts(selectedStore, _storeSingleton.Stores);
      Console.WriteLine();

      currentOrder.Customer = selectedCustomer;
      currentOrder.StoreName = selectedStore.Name;
      currentOrder.Products = new List<Product>();
      do
      {
        selectedProduct = SelectAProduct(selectedStore);
        if (selectedProduct != null)
        {
          System.Console.WriteLine("You have added " + selectedProduct + " to the order.");
          Console.WriteLine();
          currentOrder.Products.Add(selectedProduct);
        }
      }
      while (selectedProduct != null);

      if (currentOrder.Products.Count > 0)
      {
        Console.WriteLine("Purchase complete, see receipt below: ");
        Console.WriteLine();

        _orderSingleton.Orders.Add(currentOrder);
        // _orderSingleton.SaveOrders();

        _orderSingleton.PrintCurrentOrder(currentOrder);
      }
      else
      {
        Console.WriteLine("You have not purchased any products.");
      }

      var selecetedOrder = OrderList();
      if (selecetedOrder == 1)
      {
        _orderSingleton.PrintOrders(selectedCustomer);
      }
      else if (selecetedOrder == 2)
      {
        _orderSingleton.PrintOrders(selectedStore);
      }
      else
      {
        Console.WriteLine("Thank you.");
      }

      // _orderSingleton.PrintOrders(selectedCustomer);
      //  _orderSingleton.PrintOrders(selectedStore);

      // Console.WriteLine(JsonConvert.SerializeObject(currentOrder, Formatting.Indented));
      // possible implementation


    }

    static int OrderList()
    {
      Console.WriteLine("1 - Show Customer orders, 2 - Show Store orders, Any key - Quit");
      int orderList;
      try
      {
        orderList = int.Parse(Console.ReadLine());
      }
      catch
      {
        orderList = 0;
      }

      return orderList;

    }


    static void PrintAllStoreLocations()
    {
      Log.Information("Print Store");

      // var storeRepository = new StoreRepository();
      int i = 1;

      foreach (var store in _storeSingleton.Stores)
      {
        System.Console.WriteLine(i + " - " + store);
        i++;
      }
    }

    static void PrintCustomerId()
    {
      Log.Information("Print Id");

      // var customerRepository = new CustomerRepository();
      int i = 1;

      // foreach (var id in customerRepository.Customers)
      foreach (var id in _customerSingleton.Customers)
      {
        System.Console.WriteLine("Customer ID: " + i + " - " + id);
        i++;
      }
      Console.WriteLine();
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
      Boolean validInput = false;
      int option;
      try
      {
        option = int.Parse(Console.ReadLine());
      }
      catch
      {
        option = 0;
      }
      while (!validInput)
      {
        if (option <= 0 || option > _customerSingleton.Customers.Count)
        {
          Console.WriteLine("Please select a correct Store: 1, 2 or 3");
          try
          {
            option = int.Parse(Console.ReadLine());
          }
          catch
          {
            option = 0;
          }
        }
        else validInput = true;
      }
      var store = location[option - 1];

      return store;
    }
    static Product SelectAProduct(Store selectedStoreX)
    {
      var product = selectedStoreX.Products;
      Boolean validInput = false;
      int option;

      Console.WriteLine("Select a Product or 0 to purchase products: ");
      try
      {
        option = int.Parse(Console.ReadLine());
      }
      catch
      {
        option = -1;
      }
      while (!validInput)
      {
        if (option < 0 || option > _customerSingleton.Customers.Count)
        {
          Console.WriteLine("Please select a correct Product: 1, 2 or 3");
          try
          {
            option = int.Parse(Console.ReadLine());
          }
          catch
          {
            option = -1;
          }
        }
        else validInput = true;
      }

      if (option == 0)
      {
        return null;
      }
      else
      {
        var selection = product[option - 1];

        return selection;
      }
    }

    static Customer SelectCustomer()
    {
      //var customer = new CustomerRepository().Customers;
      var customer = _customerSingleton.Customers;

      Console.WriteLine("Select a Customer ID: ");
      Boolean validInput = false;
      int option;
      try
      {
        option = int.Parse(Console.ReadLine());
      }
      catch
      {
        option = 0;
      }
      while (!validInput)
      {
        if (option <= 0 || option > _customerSingleton.Customers.Count)
        {
          Console.WriteLine("Please select a correct ID: 1, 2 or 3");
          try
          {
            option = int.Parse(Console.ReadLine());
          }
          catch
          {
            option = 0;
          }
        }
        else validInput = true;
      }
      var id = customer[option - 1];

      return id;
    }
    /// <summary>
    /// Initializes and populates stores
    /// </summary>
    static void InitStores()
    {
      var populate = _storeSingleton;
      populate.PopulateStores();
    }

  }
}
