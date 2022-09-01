using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;

namespace PruebaGeeksHubs.Infrastructure.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly TiendaDbContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public ComprasRepository(TiendaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapperConfig = mapper.ConfigurationProvider;
        }

        public async Task<T> GetCompraById<T>(int compraId, CancellationToken cancellationToken)
        {
            var query = _context.Compras
                .AsNoTracking()
                .Where(x => x.CompraId == compraId)
                .ProjectTo<T>(_mapperConfig);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> GetComprasByCliente<T>(int clienteId, CancellationToken cancellationToken)
        {
            var query = _context.Compras
                .AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .ProjectTo<T>(_mapperConfig);

            return await query
                .ToListAsync(cancellationToken);
        }

        public async Task<Compra> CreateCompra(Compra compras, CancellationToken cancellationToken)
        {
            await _context.Compras.AddAsync(compras, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return compras;
        }
    }
}
