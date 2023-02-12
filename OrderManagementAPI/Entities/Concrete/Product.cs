using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int GTIN { get; set; }

        public short Quantity { get; set; }

        public decimal UnitPrice { get; set; }


        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
