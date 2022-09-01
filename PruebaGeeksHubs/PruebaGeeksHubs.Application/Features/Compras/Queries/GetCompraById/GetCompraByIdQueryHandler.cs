using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Compras.Queries.GetCompraById
{
    public class GetCompraByIdQueryHandler : IRequestHandler<GetCompraByIdQuery, CompraResponseDTO>
    {
        private readonly IComprasRepository _repository;

        public GetCompraByIdQueryHandler(IComprasRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompraResponseDTO> Handle(GetCompraByIdQuery request, CancellationToken cancellationToken)
        {
            CompraResponseDTO compra = await _repository.GetCompraById<CompraResponseDTO>(request.CompraId, cancellationToken);

            return compra != null ? await Task.FromResult(compra) : null;
        }
    }
}
