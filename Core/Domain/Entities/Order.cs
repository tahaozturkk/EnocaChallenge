using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order: BaseEntity
    {
        public string CustomerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Guid FirmId { get; set; }
        public Firm Firm { get; set; }
    }
}
