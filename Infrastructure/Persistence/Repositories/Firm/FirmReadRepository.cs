using Application.Repositories.Firm;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Firm
{
    public class FirmReadRepository : ReadRepository<Domain.Entities.Firm>, IFirmReadRepository
    {
        public FirmReadRepository(EnocaChallengeDbContext context) : base(context)
        {
        }
    }
}
