namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {

    public string Name { get; set; }

    public string Category { get; set; }

    public int ProductId { get; set; }

    public override string ToString()
    {
      return Name;
    }

  }
}