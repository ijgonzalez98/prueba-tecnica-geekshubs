using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand : IRequest<ProductoResponseDTO>
    {
        public int ProductoId { get; set; }
        public readonly UpdateProductoRequestData Data;

        public UpdateProductoCommand(int productoId, UpdateProductoRequestData data)
        {
            ProductoId = productoId;
            Data = data;
        }

        public class UpdateProductoRequestData
        {
            public int? CategoriaId { get; set; }
            public string? Nombre { get; set; }
            public decimal? Precio { get; set; }
        }
    }
}
