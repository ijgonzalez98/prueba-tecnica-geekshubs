using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Clientes.Queries.GetClienteById
{
    internal class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClienteResponseDTO>
    {
        private readonly IClientesRepository _repository;

        public GetClienteByIdQueryHandler(IClientesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteResponseDTO> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            ClienteResponseDTO cliente = await _repository.GetClienteById<ClienteResponseDTO>(request.ClienteId, cancellationToken);

            return cliente != null ? await Task.FromResult(cliente) : null;
        }
    }
}
