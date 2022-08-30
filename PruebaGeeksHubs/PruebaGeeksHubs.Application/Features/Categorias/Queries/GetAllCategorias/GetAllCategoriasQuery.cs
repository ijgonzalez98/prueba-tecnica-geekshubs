using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<List<CategoriaResponseDTO>>
    {
    }
}
