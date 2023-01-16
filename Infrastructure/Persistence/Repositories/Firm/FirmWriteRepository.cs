using Application.Repositories.Firm;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Firm
{
    public class FirmWriteRepository : WriteRepository<Domain.Entities.Firm>, IFirmWriteRepository
    {
        public FirmWriteRepository(EnocaChallengeDbContext context) : base(context)
        {
        }
    }
}
