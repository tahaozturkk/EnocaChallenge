using Application.Exceptions.Firm;
using Application.Repositories.Firm;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Firm.AddFirm
{
    public class AddFirmCommandHandler : IRequestHandler<AddFirmCommandRequest, AddFirmCommandResponse>
    {
        readonly IFirmWriteRepository _firmWriteRepository;
        readonly IFirmReadRepository _firmReadRepository;
        public AddFirmCommandHandler(IFirmWriteRepository firmWriteRepository, IFirmReadRepository firmReadRepository)
        {
            _firmWriteRepository = firmWriteRepository;
            _firmReadRepository = firmReadRepository;
        }
        public async Task<AddFirmCommandResponse> Handle(AddFirmCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Firm firmControl =  await _firmReadRepository.GetSingleAsync(x => x.Name == request.Name);

            if (firmControl == null)
            {
                await _firmWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    FirmState = request.FirmState,
                    OrderEndTime = request.OrderEndTime,
                    OrderStartTime = request.OrderStartTime,
                });
                await _firmWriteRepository.SaveAsync();
            }
            else
            {
                throw new Exception("Firma daha önce eklenmiş!.");
            }  

            return new()
            {
                Message = "Firma başarıyla eklenmiştir."
            };
        }
    }
}
