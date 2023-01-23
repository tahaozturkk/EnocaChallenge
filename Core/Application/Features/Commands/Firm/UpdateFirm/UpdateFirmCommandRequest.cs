using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Firm.UpdateFirm
{
    public class UpdateFirmCommandRequest: IRequest<UpdateFirmCommandResponse>
    {
        public string FirmName { get; set; }
        public bool FirmState { get; set; }
        public DateTime? OrderStartTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
    }
}
