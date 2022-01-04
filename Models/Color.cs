using System;
using System.Collections.Generic;

namespace ConsumerCellular.NET.Models
{
    public partial class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public int ColorId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
