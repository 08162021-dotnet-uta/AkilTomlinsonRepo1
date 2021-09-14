using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContext.Models
{
    public partial class ViewStoreOrder
    {
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
