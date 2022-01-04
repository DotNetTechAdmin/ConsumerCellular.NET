using System;
using System.Collections.Generic;

namespace ConsumerCellular.NET.Models
{
    public partial class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ProductOwnershipId { get; set; }
        public int ColorId { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual ProductOwnership ProductOwnership { get; set; } = null!;
    }
}
