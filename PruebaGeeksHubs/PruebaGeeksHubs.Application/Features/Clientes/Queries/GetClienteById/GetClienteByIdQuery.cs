using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<ClienteResponseDTO>
    {
        public int ClienteId { get; set; }
    }
}
