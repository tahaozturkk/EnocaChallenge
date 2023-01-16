using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest: IRequest<CreateOrderCommandResponse>
    {
        public string CustomerName { get; set; }
        public Guid ProductId { get; set; }
        public Guid FirmId { get; set; }
    }
}
