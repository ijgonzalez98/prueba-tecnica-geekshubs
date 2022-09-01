using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Compras.Queries.GetComprasByCliente
{
    public class GetComprasByClienteQuery : IRequest<List<CompraResponseDTO>>
    {
        public int ClienteId { get; set; }
    }
}
