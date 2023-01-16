using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Firm: BaseEntity
    {
        
        public string Name { get; set; }
        public bool FirmState { get; set; }
        public DateTime? OrderStartTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
