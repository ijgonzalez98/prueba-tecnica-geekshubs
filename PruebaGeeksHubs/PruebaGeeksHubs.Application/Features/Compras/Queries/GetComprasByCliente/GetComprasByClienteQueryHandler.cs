using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Compras.Queries.GetComprasByCliente
{
    public class GetComprasByClienteQueryHandler : IRequestHandler<GetComprasByClienteQuery, List<CompraResponseDTO>>
    {
        private readonly IComprasRepository _repository;

        public GetComprasByClienteQueryHandler(IComprasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompraResponseDTO>> Handle(GetComprasByClienteQuery request, CancellationToken cancellationToken)
        {
            List<CompraResponseDTO> cliente = await _repository.GetComprasByCliente<CompraResponseDTO>(request.ClienteId, cancellationToken);

            return cliente != null ? await Task.FromResult(cliente) : null;
        }
    }
}
