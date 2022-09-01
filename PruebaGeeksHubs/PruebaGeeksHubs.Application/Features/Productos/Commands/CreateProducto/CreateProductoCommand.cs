using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommand : IRequest<ProductoResponseDTO>
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
