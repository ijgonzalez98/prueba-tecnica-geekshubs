using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.Features.Categorias.Commands.CreateCategoria;
using PruebaGeeksHubs.Application.Features.Categorias.Commands.DeleteCategoria;
using PruebaGeeksHubs.Application.Features.Categorias.Commands.UpdateCategoria;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetAllCategorias;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetProductosByCategoria;

namespace PruebaGeeksHubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GET

        [HttpGet("{categoriaId:int}")]
        public async Task<IActionResult> GetCategoriaById([FromRoute] int categoriaId)
        {
            var query = new GetCategoriaByIdQuery
            {
                CategoriaId = categoriaId
            };

            var response = await _mediator.Send(query);

            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("{categoriaId:int}/productos")]
        public async Task<IActionResult> GetProductosByCategoria([FromRoute] int categoriaId)
        {
            var query = new GetProductosByCategoriaQuery
            {
                CategoriaId = categoriaId
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _mediator.Send(new GetAllCategoriasQuery()));
        }

        #endregion GET

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoriaCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        #endregion POST

        #region PATCH

        [HttpPatch("{categoriaId:int}")]
        public async Task<IActionResult> Patch(
            [FromRoute] int categoriaId,
            [FromBody] UpdateCategoriaCommand.UpdateCategoriaRequestData request)
        {
            var command = new UpdateCategoriaCommand(categoriaId, request);

            var response = await _mediator.Send(command);

            return response != null ? Ok(response) : NotFound();
        }

        #endregion PATCH

        #region DELETE

        [HttpDelete("{categoriaId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int categoriaId)
        {
            var command = new DeleteCategoriaCommand
            {
                CategoriaId = categoriaId
            };

            var response = await _mediator.Send(command);

            return response ? Ok() : NoContent();
        }

        #endregion DELETE
    }
}
