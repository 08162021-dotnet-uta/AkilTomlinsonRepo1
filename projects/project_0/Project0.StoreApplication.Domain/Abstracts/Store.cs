namespace Project0.StoreApplication.Domain.Abstracts
{
  public abstract class Store
  {
    public string Name { get; protected set; }

    public override string ToString()
    {
      return Name;
    }
  }
}