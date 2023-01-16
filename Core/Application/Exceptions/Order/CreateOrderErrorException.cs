using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Order
{
    public class CreateOrderErrorException : Exception
    {
        public CreateOrderErrorException() : base("Firma onaylı değil veya sipariş saatleri arasında olmadığınızdan sipariş oluşturulamadı!")
        {
        }
    }
}
