using System;
using System.Collections.Generic;

namespace ConsumerCellular.NET.Models
{
    public partial class CellPhone
    {
        public int CellPhoneId { get; set; }
        public int StorageSize { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
