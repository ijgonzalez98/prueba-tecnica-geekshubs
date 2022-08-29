using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQuery : IRequest<CategoriaResponseDTO>
    {
        public int CategoriaId { get; set; }
    }
}
