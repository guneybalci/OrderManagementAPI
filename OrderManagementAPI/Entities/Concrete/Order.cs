using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{

    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int GTIN { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
