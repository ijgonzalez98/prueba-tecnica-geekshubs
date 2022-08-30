using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface IClientesRepository
    {
        Task<T> GetClienteById<T>(int clienteId, CancellationToken cancellationToken);
        Task<Cliente> CreateCliente(Cliente cliente, CancellationToken cancellationToken);
        Task<Cliente> UpdateCliente(Cliente cliente, CancellationToken cancellationToken);
    }
}
