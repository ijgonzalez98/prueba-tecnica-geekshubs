using MediatR;
using PruebaGeeksHubs.Application.DTOs.Requests;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<ClienteResponseDTO>
    {
        public int ClienteId { get; set; }
        public UpdateClienteDTO RequestBody { get; set; } = null!;
    }
}
