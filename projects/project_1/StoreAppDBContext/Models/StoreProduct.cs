using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContext.Models
{
    public partial class StoreProduct
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
