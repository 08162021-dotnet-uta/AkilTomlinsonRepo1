using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using dbprod = StoreAppDBContext.Models.Product;

namespace StoreAppBusiness
{
    public class ProductRepository : IProductRepository
    {
        public AkilApplicationDBContext _context;

        public ProductRepository(AkilApplicationDBContext context)
        {
            _context = context;
        }

        public void ProductList()
        {
            var products = _context.Products.FromSqlRaw<dbprod>("SELECT * FROM Product").ToList();
            int i = 1;
            foreach (var x in products)
            {
                Console.WriteLine("Product " + i + ": " + $"{x.ProductName} {x.ProductDescription} {x.ProductPrice}");
                i++;

            }
        }

        public void StoreProductList(string store)
        {
            string statement = $"SELECT * FROM ViewStoreProducts WHERE StoreId={store}";
            var storeProducts = _context.ViewStoreProducts.FromSqlRaw(statement).ToList();

            foreach (var x in storeProducts)
            {
                Console.WriteLine($"{x.ProductId} {x.ProductName} {x.ProductDescription} {x.ProductPrice}");

            }
        }







        public ProductRepository()
        {
        }
    }
}
