using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContext.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreProducts = new HashSet<StoreProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
