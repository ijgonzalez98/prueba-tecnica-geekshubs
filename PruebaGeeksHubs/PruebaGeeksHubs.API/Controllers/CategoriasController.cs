using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGeeksHubs.Application.Features.Categorias.Commands.CreateCategoria;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetAllCategorias;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById;

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
            return Ok(await _mediator.Send(command));
        }

        #endregion POST
    }
}
