using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
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
    private const string _logFilePath = @"/Users/atmac/revature/akil_repo/data/log.txt";
    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>

    static void Main(string[] args)
    {
      StartApp();
    }

    static void StartApp()
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();

      Customer selectedCustomer; //Current customer
      Store selectedStore; //Current store with products
      Order currentOrder = new Order(); //Current order
      Product selectedProduct; //product to be added to order

      _storeSingleton.PopulateStores();
      _customerSingleton.PrintCustomerId();

      selectedCustomer = SelectCustomer();
      System.Console.WriteLine("Welcome back: " + selectedCustomer);
      Console.WriteLine();
      _storeSingleton.PrintAllStoreLocations();
      Console.WriteLine();

      selectedStore = SelectAStore();
      System.Console.WriteLine("You have selected the: " + selectedStore);
      Console.WriteLine();

      _storeSingleton.PrintStoreProducts(selectedStore, _storeSingleton.Stores);
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
        _orderSingleton.SaveOrders();

        _orderSingleton.PrintCurrentOrder(currentOrder);
      }
      else
      {
        Log.Warning("Selected purchase with an empty order.");
        Console.WriteLine("You have not purchased any products.");
      }

      var selecetedOrder = _orderSingleton.OrderList();
      if (selecetedOrder == 1)
      {
        _orderSingleton.PrintOrders(selectedCustomer);
        Console.WriteLine();
      }
      else if (selecetedOrder == 2)
      {
        _orderSingleton.PrintOrders(selectedStore);
        Console.WriteLine();
      }
      else
      {
        Console.WriteLine("Thank you.");
      }

    }
    /// <summary>
    /// Checks input to select a store, outputs store if input correct.
    /// </summary>
    /// <returns></returns>
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
          Log.Warning("Store selection incorrect.");
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
    /// <summary>
    /// Checks input to select a product, outputs product to be added to order if input correct.
    /// </summary>
    /// <param name="inputStore"></param>
    /// <returns></returns>
    static Product SelectAProduct(Store inputStore)
    {
      var product = inputStore.Products;
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
          Log.Warning("Product selection incorrect.");
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
    /// <summary>
    /// Checks input to select a customer, outputs customer if input correct.
    /// </summary>
    /// <returns></returns>
    static Customer SelectCustomer()
    {
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
          Log.Warning("Customer ID selection incorrect.");
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

  }//EoC
}//EoN
