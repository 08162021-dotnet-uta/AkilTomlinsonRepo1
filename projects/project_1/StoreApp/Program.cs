using System;
using StoreAppBusiness;



namespace StoreApp
{
    class Program
  {
    static void Main(string[] args)
        {
            CustomerRepository custRepo = new CustomerRepository();
            ProductRepository productRepo = new ProductRepository();
            StoreRepository storeRepo = new StoreRepository();

            custRepo.CustomerList();
            var selectedCustomer = Console.ReadLine();
            custRepo.CustOrderList(selectedCustomer);
            //productRepo.ProductList();
            storeRepo.StoreList();
            var selectedStore = Console.ReadLine();
            storeRepo.StoreOrderList(selectedStore);
            productRepo.StoreProductList(selectedStore);

        }
   }//EoC
}//EoF