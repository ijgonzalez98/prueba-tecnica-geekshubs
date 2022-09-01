using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ClienteResponseDTO>
    {
        private readonly IClientesRepository _repository;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IClientesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteResponseDTO> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente cliente = await _repository.GetClienteById<Cliente>(request.ClienteId, cancellationToken);

            if (cliente == null) return null;

            cliente.Nombre = request.Data.Nombre ?? cliente.Nombre;
            cliente.Apellidos = request.Data.Apellidos ?? cliente.Apellidos;
            cliente.Telefono = request.Data.Telefono ?? cliente.Telefono;
            cliente.FechaNacimiento = request.Data.FechaNacimiento ?? cliente.FechaNacimiento;
            cliente.Email = request.Data.Email ?? cliente.Email;

            var response = _mapper.Map<ClienteResponseDTO>(await _repository.UpdateCliente(cliente, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
