using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Firm
{
    public class UpdateFirmErrorException : Exception
    {
        public UpdateFirmErrorException() : base("Firma güncellenirken beklenmedik bir hatayla karşılaşılmıştır!")
        {
        }
    }
}
