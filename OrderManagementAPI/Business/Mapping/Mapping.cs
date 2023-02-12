using Entities.Concrete;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapping
{
    public static class Mapping
    {
        public static CreateIndexDescriptor ProductMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Product>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Number(t => t.Name(n => n.CategoryId))
                .Text(t => t.Name(n => n.Name))
                .Number(t => t.Name(n => n.GTIN))
                .Number(t => t.Name(n => n.Quantity))
                .Number(t => t.Name(n => n.UnitPrice)))
            );
        }
    }
}
