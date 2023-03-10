using Application.Abstractions.Services;
using Application.Repositories.Firm;
using Application.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
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
            services.AddDbContext<EnocaChallengeDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

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
