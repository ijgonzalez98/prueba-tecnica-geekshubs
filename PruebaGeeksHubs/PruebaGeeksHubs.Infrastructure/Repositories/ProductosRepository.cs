using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;

namespace PruebaGeeksHubs.Infrastructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly TiendaDbContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public ProductosRepository(TiendaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapperConfig = mapper.ConfigurationProvider;
        }

        public async Task<T> GetProductoById<T>(int productoId, CancellationToken cancellationToken)
        {
            var query = _context.Productos
                .AsNoTracking()
                .Where(x => x.ProductoId == productoId)
                .ProjectTo<T>(_mapperConfig);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> GetProductosByCategoria<T>(int categoriaId, CancellationToken cancellationToken)
        {
            var query = _context.Productos
                .AsNoTracking()
                .Where(x => x.CategoriaId == categoriaId)
                .ProjectTo<T>(_mapperConfig);

            return await query
                .ToListAsync(cancellationToken);
        }

        public async Task<Producto> CreateProducto(Producto producto, CancellationToken cancellationToken)
        {
            await _context.Productos.AddAsync(producto, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return producto;
        }

        public async Task<Producto> UpdateProducto(Producto producto, CancellationToken cancellationToken)
        {
            var entity = await _context.Productos.FindAsync(producto.ProductoId);

            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(producto);
            await _context.SaveChangesAsync(cancellationToken);

            return producto;
        }
    }
}
