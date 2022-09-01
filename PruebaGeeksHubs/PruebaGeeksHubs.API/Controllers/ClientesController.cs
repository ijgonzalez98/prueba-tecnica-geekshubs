using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.Features.Clientes.Commands.CreateCliente;
using PruebaGeeksHubs.Application.Features.Clientes.Commands.UpdateCliente;
using PruebaGeeksHubs.Application.Features.Clientes.Queries.GetClienteById;
using PruebaGeeksHubs.Application.Features.Compras.Commands.CreateCompraByCliente;
using PruebaGeeksHubs.Application.Features.Compras.Queries.GetComprasByCliente;

namespace PruebaGeeksHubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GET

        [HttpGet("{clienteId:int}")]
        public async Task<IActionResult> GetClienteById([FromRoute] int clienteId)
        {
            var query = new GetClienteByIdQuery
            {
                ClienteId = clienteId
            };

            var response = await _mediator.Send(query);

            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("{clienteId:int}/compras")]
        public async Task<IActionResult> GetComprasByCliente([FromRoute] int clienteId)
        {
            var query = new GetComprasByClienteQuery
            {
                ClienteId = clienteId
            };

            return Ok(await _mediator.Send(query));
        }

        #endregion GET

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpPost("{clienteId:int}/compra")]
        public async Task<IActionResult> CreateCompraByCliente(
            [FromRoute] int clienteId,
            [FromBody] CreateCompraByClienteCommand.CreateCompraByClienteRequestData request)
        {
            var command = new CreateCompraByClienteCommand(clienteId, request);

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion POST

        #region PATCH

        [HttpPatch("{clienteId:int}")]
        public async Task<IActionResult> Patch(
            [FromRoute] int clienteId,
            [FromBody] UpdateClienteCommand.UpdateClienteRequestData request)
        {
            var command = new UpdateClienteCommand(clienteId, request);

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion PATCH
    }
}
