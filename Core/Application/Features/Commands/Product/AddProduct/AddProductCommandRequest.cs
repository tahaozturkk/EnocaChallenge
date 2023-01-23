using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.AddProduct
{
    public class AddProductCommandRequest: IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string FirmName { get; set; }
    }
}
