using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductoResponseDTO>
    {
        public int ProductoId { get; set; }
    }
}
