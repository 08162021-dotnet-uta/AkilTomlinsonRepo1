using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContext.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            StoreProducts = new HashSet<StoreProduct>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
