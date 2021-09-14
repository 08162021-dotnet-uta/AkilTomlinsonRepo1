using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContext.Models
{
    public partial class ViewStoreProduct
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string StoreName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
