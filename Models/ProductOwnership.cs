using System;
using System.Collections.Generic;

namespace ConsumerCellular.NET.Models
{
    public partial class ProductOwnership
    {
        public ProductOwnership()
        {
            ProductColors = new HashSet<ProductColor>();
            Products = new HashSet<Product>();
        }

        public int ProductOwnershipId { get; set; }
        public string ProductName { get; set; } = null!;
        public string OwnerName { get; set; } = null!;

        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
