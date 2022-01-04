using System;
using System.Collections.Generic;

namespace ConsumerCellular.NET.Models
{
    public partial class Product
    {
        public Product()
        {
            CellPhones = new HashSet<CellPhone>();
        }

        public int ProductId { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal PriceAcquisition { get; set; }
        public int ProductOwnerId { get; set; }
        public int ProductTypeId { get; set; }

        public virtual ProductOwnership ProductOwner { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
        public virtual ICollection<CellPhone> CellPhones { get; set; }
    }
}
