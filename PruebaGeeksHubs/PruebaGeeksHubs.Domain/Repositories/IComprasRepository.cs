using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface IComprasRepository
    {
        Task<T> GetCompraById<T>(int compraId, CancellationToken cancellationToken);
        Task<List<T>> GetComprasByCliente<T>(int clienteId, CancellationToken cancellationToken);
        Task<Compra> CreateCompra(Compra compras, CancellationToken cancellationToken);
    }
}
