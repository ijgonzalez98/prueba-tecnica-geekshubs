using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        #endregion GET
    }
}
