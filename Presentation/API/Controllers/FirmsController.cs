using Application.Features.Commands.Firm.AddFirm;
using Application.Features.Commands.Firm.UpdateFirm;
using Application.Features.Queries.Firm.GetAllFirms;
using Application.Repositories.Product;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmsController : ControllerBase
    {
        readonly IMediator _mediator;
        public FirmsController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFirms([FromQuery]GetAllFirmsQueryRequest getAllFirmsQueryRequest)
        {
           GetAllFirmsQueryResponse response = await _mediator.Send(getAllFirmsQueryRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddFirm(AddFirmCommandRequest addFirmCommandRequest)
        {
            AddFirmCommandResponse response = await _mediator.Send(addFirmCommandRequest);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFirm(UpdateFirmCommandRequest updateFirmCommandRequest)
        {
            UpdateFirmCommandResponse response = await _mediator.Send(updateFirmCommandRequest);
            return Ok(response);
        }


    }
}
