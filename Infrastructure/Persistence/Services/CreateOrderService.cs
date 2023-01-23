using Application.Abstractions.Services;
using Application.Exceptions.Order;
using Application.Repositories.Firm;
using Application.Repositories.Product;

namespace Persistence.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IFirmReadRepository _firmReadRepository;
        readonly IProductReadRepository _productReadRepository;
        public CreateOrderService(IOrderWriteRepository orderWriteRepository, IFirmReadRepository firmReadRepository, IProductReadRepository productReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _firmReadRepository = firmReadRepository;
            _productReadRepository = productReadRepository;
        }
        public async Task CreateOrderAsync(string customerName, string firmName, string productName)
        {
            Domain.Entities.Product product = await _productReadRepository.GetSingleAsync(x => x.Name == productName);
            Domain.Entities.Firm firm = await _firmReadRepository.GetSingleAsync(x => x.Name == firmName);

            if (product != null && firm != null)
            {
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
                        CustomerName = customerName,
                        FirmId = firm.Id,
                        ProductId = product.Id
                    };
                    await _orderWriteRepository.AddAsync(order);
                    await _orderWriteRepository.SaveAsync();
                }
                else
                {
                    throw new CreateOrderErrorException();
                }
            }
            else
                throw new Exception("İlgili ürün veya firma bulunamadı!");
        }
    }
}
