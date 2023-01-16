using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public Firm Firm { get; set; }
        public Guid FirmId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
