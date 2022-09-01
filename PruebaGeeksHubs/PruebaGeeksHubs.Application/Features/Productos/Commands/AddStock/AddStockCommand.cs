using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.AddStock
{
    public class AddStockCommand : IRequest<ProductoResponseDTO>
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
