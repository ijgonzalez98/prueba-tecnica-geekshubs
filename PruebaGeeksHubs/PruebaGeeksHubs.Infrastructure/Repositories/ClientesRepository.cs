using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;

namespace PruebaGeeksHubs.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly TiendaDbContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public ClientesRepository(TiendaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapperConfig = mapper.ConfigurationProvider;
        }

        public async Task<T> GetClienteById<T>(int clienteId, CancellationToken cancellationToken)
        {
            var query = _context.Clientes
                .AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .ProjectTo<T>(_mapperConfig);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Cliente> CreateCliente(Cliente cliente, CancellationToken cancellationToken)
        {
            await _context.Clientes.AddAsync(cliente, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente, CancellationToken cancellationToken)
        {
            var entity = await _context.Clientes.FindAsync(cliente.ClienteId);

            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync(cancellationToken);

            return cliente;
        }
    }
}
