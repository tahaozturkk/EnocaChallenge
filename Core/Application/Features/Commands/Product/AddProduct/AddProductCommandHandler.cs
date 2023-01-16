using Application.Exceptions.Firm;
using Application.Repositories.Firm;
using Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        public AddProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                FirmId = request.FirmId
            };

            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
