using Application.Exceptions.Firm;
using Application.Repositories.Firm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Firm.UpdateFirm
{
    public class UpdateFirmCommandHandler : IRequestHandler<UpdateFirmCommandRequest, UpdateFirmCommandResponse>
    {
        readonly IFirmWriteRepository _firmWriteRepository;
        readonly IFirmReadRepository _firmReadRepository;
        public UpdateFirmCommandHandler(IFirmWriteRepository firmWriteRepository, IFirmReadRepository firmReadRepository)
        {
            _firmWriteRepository = firmWriteRepository;
            _firmReadRepository = firmReadRepository;
        }
        public async Task<UpdateFirmCommandResponse> Handle(UpdateFirmCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Firm firm = await _firmReadRepository.GetSingleAsync(x => x.Name == request.FirmName);
            if (firm != null)
            {
                firm.FirmState = request.FirmState;
                firm.OrderStartTime = request.OrderStartTime;
                firm.OrderEndTime = request.OrderEndTime;
                _firmWriteRepository.Update(firm);
                await _firmWriteRepository.SaveAsync();
            }
            else
                throw new Exception("Böyle bir firma bulunamamıştır!");

            return new()
            {
                Message = "Firma bilgileri başarıyla güncellenmiştir."
            };
        }
    }
}
