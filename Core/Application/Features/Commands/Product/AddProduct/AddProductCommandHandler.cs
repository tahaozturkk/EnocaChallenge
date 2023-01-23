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
        readonly IFirmReadRepository _firmReadRepository;
        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, IFirmReadRepository firmReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _firmReadRepository = firmReadRepository;
        }
        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Firm firm = await _firmReadRepository.GetSingleAsync(x => x.Name == request.FirmName);
            if (firm != null)
            {
                Domain.Entities.Product product = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock,
                    FirmId = firm.Id,
                };

                await _productWriteRepository.AddAsync(product);
                await _productWriteRepository.SaveAsync();
            }
            else
                throw new Exception($"Ürün ekleme işlemi başarısız! {request.FirmName} isimli firma bulunamadı.");

            return new()
            {
                Message = $"Ürünler {firm.Name} firmasına başarıyla eklenmiştir."
            };
        }
    }
}
