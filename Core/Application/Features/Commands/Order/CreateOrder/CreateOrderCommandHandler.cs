using Application.Exceptions.Order;
using Application.Repositories.Firm;
using Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IFirmReadRepository _firmReadRepository;
        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IFirmReadRepository firmReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _firmReadRepository = firmReadRepository;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Firm firm = await _firmReadRepository.GetByIdAsync(Convert.ToString(request.FirmId));
            bool FirmState = firm.FirmState;
            DateTime? FirmOrderStartTime = firm.OrderStartTime;
            DateTime? FirmOrderEndTime = firm.OrderEndTime;
            DateTime DateTimeNow = DateTime.Now;

            if (FirmState && FirmOrderStartTime < DateTimeNow && DateTimeNow < FirmOrderEndTime)
            {
                Domain.Entities.Order order = new()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CustomerName = request.CustomerName,
                    FirmId = request.FirmId,
                    ProductId = request.ProductId
                };
                await _orderWriteRepository.AddAsync(order);
                await _orderWriteRepository.SaveAsync();
                
            }
            else
            {
                throw new CreateOrderErrorException();
            }

            return new();
        }
    }
}
