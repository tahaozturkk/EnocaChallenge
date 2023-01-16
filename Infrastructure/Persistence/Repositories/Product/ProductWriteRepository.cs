using Application.Repositories.Firm;
using Application.Repositories.Product;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EnocaChallengeDbContext context) : base(context)
        {
        }
    }
}
