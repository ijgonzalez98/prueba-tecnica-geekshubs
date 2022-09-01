using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.Features.Compras.Queries.GetCompraById;

namespace PruebaGeeksHubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GET

        [HttpGet("{compraId:int}")]
        public async Task<IActionResult> GetCompraById([FromRoute] int compraId)
        {
            var query = new GetCompraByIdQuery
            {
                CompraId = compraId
            };

            var response = await _mediator.Send(query);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion GET
    }
}
