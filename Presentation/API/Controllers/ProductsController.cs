using Application.Features.Commands.Firm.AddFirm;
using Application.Features.Commands.Product.AddProduct;
using Application.Repositories.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse response = await _mediator.Send(addProductCommandRequest);
            return Ok(response);
        }

    }
}
