using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Abstracts
{
  [XmlInclude(typeof(ClothingStore))]
  [XmlInclude(typeof(GroceryStore))]
  [XmlInclude(typeof(JeweleryStore))]

  /// <summary>
  /// No longer abstract due to database implementation
  /// </summary>
  public class Store
  {
    public string Name { get; set; }
    public List<Product> Products { get; set; }

    public List<Order> Orders { get; set; }
    public int StoreId { get; set; }


    public override string ToString()
    {
      return Name;
    }
  }
}