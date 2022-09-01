using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;

namespace PruebaGeeksHubs.Application.Features.Compras.Queries.GetCompraById
{
    public class GetCompraByIdQuery : IRequest<CompraResponseDTO>
    {
        public int CompraId { get; set; }
    }
}
