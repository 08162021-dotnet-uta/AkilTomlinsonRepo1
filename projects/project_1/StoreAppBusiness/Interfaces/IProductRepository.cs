using System;

namespace StoreAppBusiness.Interfaces
{
    public interface IProductRepository
    {
        void ProductList();
        void StoreProductList(string store);
    }
}
