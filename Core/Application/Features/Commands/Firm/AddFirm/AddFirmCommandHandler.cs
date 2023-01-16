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
        public AddFirmCommandHandler(IFirmWriteRepository firmWriteRepository)
        {
            _firmWriteRepository = firmWriteRepository;
        }
        public async Task<AddFirmCommandResponse> Handle(AddFirmCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Firm firm = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                FirmState = request.FirmState,
                OrderEndTime = request.OrderEndTime,
                OrderStartTime = request.OrderStartTime,
            };
            try{
                await _firmWriteRepository.AddAsync(firm);
                await _firmWriteRepository.SaveAsync();
            }catch
            {
                throw new AddFirmErrorException();
            }

            return new();
        }
    }
}
