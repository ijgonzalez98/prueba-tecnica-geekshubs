using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.CreateCategoria
{
    public class CreateCategoriaCommand : IRequest<CategoriaResponseDTO>
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
