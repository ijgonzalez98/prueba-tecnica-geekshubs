using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;

namespace PruebaGeeksHubs.Infrastructure.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly TiendaDbContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public CategoriasRepository(TiendaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapperConfig = mapper.ConfigurationProvider;
        }

        public async Task<T> GetCategoriaById<T>(int categoriaId, CancellationToken cancellationToken)
        {
            var query = _context.Categoria
                .AsNoTracking()
                .Where(x => x.CategoriaId == categoriaId)
                .ProjectTo<T>(_mapperConfig);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> GetAllCategorias<T>(CancellationToken cancellationToken)
        {
            var query = _context.Categoria
                .AsNoTracking()
                .ProjectTo<T>(_mapperConfig);

            return await query
                .ToListAsync(cancellationToken);
        }

        public async Task<Categorium> CreateCategoria(Categorium categoria, CancellationToken cancellationToken)
        {
            await _context.Categoria.AddAsync(categoria, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return categoria;
        }
    }
}
