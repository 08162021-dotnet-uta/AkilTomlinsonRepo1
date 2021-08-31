using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Order
  {
    public Customer Customer { get; set; }
    public string StoreName { get; set; }
    public List<Product> Products { get; set; }
    public int OrderId { get; set; }
  }
}