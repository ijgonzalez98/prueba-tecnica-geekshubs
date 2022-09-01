using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<ClienteResponseDTO>
    {
        public int ClienteId { get; set; }
        public readonly UpdateClienteRequestData Data;

        public UpdateClienteCommand(int clienteId, UpdateClienteRequestData data)
        {
            ClienteId = clienteId;
            Data = data;
        }

        public class UpdateClienteRequestData
        {
            public string? Nombre { get; set; }
            public string? Apellidos { get; set; }
            public string? Telefono { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public string? Email { get; set; }
        }
    }
}
