using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetProductosByCategoria
{
    public class GetProductosByCategoriaQuery : IRequest<List<ProductoResponseDTO>>
    {
        public int CategoriaId { get; set; }
    }
}
