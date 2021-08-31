using Xunit;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Client;

namespace Project.StoreApplication.Testing
{
  public class SingletonTests
  {
    [Fact]
    public void Test_StoresList()
    {
      // subject under test
      var sut = StoreSingleton.Instance;

      // data to test
      var actual = sut.Stores;

      // actual test
      Assert.NotNull(actual);
    }


    [Fact]
    public void Test_OrdersList()
    {

      var sut = OrderSingleton.Instance;


      var actual = sut.Orders;


      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_ProductsList()
    {

      var sut = ProductSingleton.Instance;


      var actual = sut.Products;


      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_CustomersList()
    {

      var sut = CustomerSingleton.Instance;


      var actual = sut.Customers;


      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_CustomersDB()
    {

      var sut = new CustomerRepositoryDB();


      var actual = sut.GetCustomers();


      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_StoreProduct()
    {

      var sut = StoreSingleton.Instance;


      var actual = sut.PopulateStores();


      Assert.NotNull(actual);
    }

  }

}