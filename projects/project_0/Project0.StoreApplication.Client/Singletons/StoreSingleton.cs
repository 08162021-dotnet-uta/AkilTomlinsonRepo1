using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{

  public class StoreSingleton
  {
    private static StoreSingleton _storeSingleton;
    private static readonly StoreRepository _storeRepository = new StoreRepository();
    public List<Store> Stores { get; set; }

    public static StoreSingleton Instance
    {
      get
      {
        if (_storeSingleton == null)
        {
          _storeSingleton = new StoreSingleton();
        }

        return _storeSingleton;
      }
    }
    private StoreSingleton()
    {
      Stores = _storeRepository.Select();
    }

    public void Add(Store store)
    {
      _storeRepository.Insert(store);
      Stores = _storeRepository.Select();
    }
    public void SaveStores(List<Store> stores)
    {
      _storeRepository.Save(stores);
      Stores = _storeRepository.Select();
    }
    /// <summary>
    /// Populates stores by category
    /// </summary>
    /// <returns></returns>
    public List<Store> PopulateStores()
    {
      var storeRepository = new StoreRepository();
      var productSingleton = ProductSingleton.Instance;

      foreach (var store in _storeSingleton.Stores)
      {
        store.Products = new List<Product>();
        foreach (var product in productSingleton.Products)
        {
          switch (store.ToString())
          {
            case "GroceryStore":
              if (product.Category == "Grocery")
              {
                store.Products.Add(product);
              }
              break;

            case "ClothingStore":
              if (product.Category == "Clothing")
              {
                store.Products.Add(product);
              }
              break;

            case "JeweleryStore":
              if (product.Category == "Jewelery")
              {
                store.Products.Add(product);
              }
              break;
          }

        }

      }
      return _storeSingleton.Stores;
    }
    /// <summary>
    /// Prints products for specific store
    /// </summary>
    /// <param name="x"></param>
    public void PrintStoreProducts(Store x)
    {
      int i = 1;
      foreach (var product in x.Products)
      {
        Console.WriteLine(i + " - " + product);
        i++;
      }
    }
    /// <summary>
    /// Prints list of stores"
    /// </summary>
    public void PrintAllStoreLocations()
    {
      int i = 1;
      foreach (var store in Stores)
      {
        System.Console.WriteLine(i + " - " + store);
        i++;
      }
    }
    /// <summary>
    /// Prints products based on store selected
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    public void PrintStoreProducts(Store x, List<Store> z)
    {

      Console.WriteLine("Products for sale: ");
      var storesSingleton = _storeSingleton;
      foreach (var y in z)
      {
        if (x.Name == y.Name)
        {
          PrintStoreProducts(y);
        }
      }
    }

  }
}