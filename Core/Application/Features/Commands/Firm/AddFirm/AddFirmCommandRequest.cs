using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Firm.AddFirm
{
    public class AddFirmCommandRequest: IRequest<AddFirmCommandResponse>
    {
        public string Name { get; set; }
        public bool FirmState { get; set; }
        public DateTime? OrderStartTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
    }
}
