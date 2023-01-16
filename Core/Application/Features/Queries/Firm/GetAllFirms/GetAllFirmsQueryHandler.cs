using Application.Repositories.Firm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Firm.GetAllFirms
{
    public class GetAllFirmsQueryHandler : IRequestHandler<GetAllFirmsQueryRequest, GetAllFirmsQueryResponse>
    {
        readonly IFirmReadRepository _firmReadRepository;
        public GetAllFirmsQueryHandler(IFirmReadRepository firmReadRepository)
        {
            _firmReadRepository = firmReadRepository;
        }

        public async Task<GetAllFirmsQueryResponse> Handle(GetAllFirmsQueryRequest request, CancellationToken cancellationToken)
        {
            var firms = _firmReadRepository.GetAll().Select(firm => new
            {
                firm.Id,
                firm.Name,
                firm.FirmState,
                firm.OrderStartTime, 
                firm.OrderEndTime,
            }).ToList();
            return new()
            {
                Firms = firms,
            };
            
        }
    }
}
