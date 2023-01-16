using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Firm
{
    public class AddFirmErrorException : Exception
    {
        public AddFirmErrorException() : base("Firma eklenirken beklenmedik bir hatayla karşılaşılmıştır!")
        {
        }
    }
}
