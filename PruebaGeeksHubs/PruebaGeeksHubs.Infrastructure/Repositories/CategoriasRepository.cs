using Microsoft.EntityFrameworkCore;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGeeksHubs.Infrastructure.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly TiendaDbContext _context;

        public CategoriasRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<Categorium> GetCategoriaById(int categoriaId, CancellationToken cancellationToken)
        {
            return await _context.Categoria
                .AsNoTracking()
                .Where(x => x.CategoriaId == categoriaId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Categorium>> GetAllCategorias(CancellationToken cancellationToken)
        {
            return await _context.Categoria
                .AsNoTracking()
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
