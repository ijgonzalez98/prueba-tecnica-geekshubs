using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommand : IRequest<CategoriaResponseDTO>
    {
        public int CategoriaId { get; set; }
        public readonly UpdateCategoriaRequestData Data;

        public UpdateCategoriaCommand(int categoriaId, UpdateCategoriaRequestData data)
        {
            CategoriaId = categoriaId;
            Data = data;
        }

        public class UpdateCategoriaRequestData
        {
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
        }
    }
}
