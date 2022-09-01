using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface IProductosRepository
    {
        Task<T> GetProductoById<T>(int productoId, CancellationToken cancellationToken);
        Task<List<T>> GetProductosByCategoria<T>(int categoriaId, CancellationToken cancellationToken);
        Task<Producto> CreateProducto(Producto producto, CancellationToken cancellationToken);
        Task<Producto> UpdateProducto(Producto producto, CancellationToken cancellationToken);
    }
}
