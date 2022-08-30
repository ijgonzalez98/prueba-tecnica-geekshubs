using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.DTOs.Requests;
using PruebaGeeksHubs.Application.Features.Clientes.Commands.CreateCliente;
using PruebaGeeksHubs.Application.Features.Clientes.Commands.UpdateCliente;
using PruebaGeeksHubs.Application.Features.Clientes.Queries.GetClienteById;

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

        #endregion GET

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        #endregion POST

        #region PATCH

        [HttpPatch("{clienteId:int}")]
        public async Task<IActionResult> Patch([FromRoute] int clienteId, [FromBody] UpdateClienteDTO request)
        {
            var command = new UpdateClienteCommand
            {
                ClienteId = clienteId,
                RequestBody = request
            };

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion PATCH
    }
}
