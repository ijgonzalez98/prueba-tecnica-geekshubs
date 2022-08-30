using MediatR;
using PruebaGeeksHubs.Application.DTOs.Requests;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommand : IRequest<CategoriaResponseDTO>
    {
        public int CategoriaId { get; set; }
        public UpdateCategoriaDTO RequestBody { get; set; } = null!;
    }
}
