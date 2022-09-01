using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.Features.Productos.Commands.AddStock;
using PruebaGeeksHubs.Application.Features.Productos.Commands.CreateProducto;
using PruebaGeeksHubs.Application.Features.Productos.Commands.UpdateProducto;
using PruebaGeeksHubs.Application.Features.Productos.Queries.GetProductoById;
using System.ComponentModel.DataAnnotations;

namespace PruebaGeeksHubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GET

        [HttpGet("{productoId:int}")]
        public async Task<IActionResult> GetProductoById([FromRoute] int productoId)
        {
            var query = new GetProductoByIdQuery
            {
                ProductoId = productoId
            };

            var response = await _mediator.Send(query);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion GET

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductoCommand command)
        {
            var response = await _mediator.Send(command);

            return response != null ? Created("", response) : NotFound();
        }

        #endregion POST

        #region PATCH

        [HttpPatch("{productoId:int}")]
        public async Task<IActionResult> Patch(
            [FromRoute] int productoId,
            [FromBody] UpdateProductoCommand.UpdateProductoRequestData request)
        {
            var command = new UpdateProductoCommand(productoId, request);

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        [HttpPatch("{productoId:int}/add-stock")]
        public async Task<IActionResult> AddStock([FromRoute] int productoId, [FromBody][Range(1, 1000)] int cantidad)
        {
            var command = new AddStockCommand
            {
                ProductoId = productoId,
                Cantidad = cantidad
            };

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion PATCH
    }
}
