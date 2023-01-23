using Application.Abstractions.Services;
using Application.Repositories.Firm;
using Application.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Firm;
using Persistence.Repositories.Order;
using Persistence.Repositories.Product;
using Persistence.Services;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IFirmWriteRepository, FirmWriteRepository>();
            services.AddScoped<IFirmReadRepository, FirmReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICreateOrderService, CreateOrderService>();

        }
    }
}
