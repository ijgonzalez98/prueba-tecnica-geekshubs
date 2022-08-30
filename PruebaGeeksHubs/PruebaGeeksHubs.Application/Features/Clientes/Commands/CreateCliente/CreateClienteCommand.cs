using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<ClienteResponseDTO>
    {
        public string Nombre { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
    }
}
