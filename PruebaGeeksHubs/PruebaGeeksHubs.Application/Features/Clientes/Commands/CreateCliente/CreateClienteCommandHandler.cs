using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClienteResponseDTO>
    {
        private readonly IClientesRepository _repository;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IClientesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteResponseDTO> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente cliente = new()
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                Telefono = request.Telefono,
                FechaNacimiento = request.FechaNacimiento,
                Email = request.Email
            };

            var response = _mapper.Map<ClienteResponseDTO>(await _repository.CreateCliente(cliente, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
