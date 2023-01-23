using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ICreateOrderService
    {
        Task CreateOrderAsync(string customerName, string firmName, string productName); 
    }
}
