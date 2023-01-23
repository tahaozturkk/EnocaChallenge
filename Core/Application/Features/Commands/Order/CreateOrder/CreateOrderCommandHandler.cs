using Application.Abstractions.Services;
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
        readonly ICreateOrderService _createOrderService;

        public CreateOrderCommandHandler(ICreateOrderService createOrderService)
        {
            _createOrderService = createOrderService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _createOrderService.CreateOrderAsync(request.CustomerName, request.FirmName, request.ProductName);
            return new()
            {
                Message = "Sipariş başarıyla oluşturulmuştur."
            };
        }
    }
}
