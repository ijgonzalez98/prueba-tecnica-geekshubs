using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface ICategoriasRepository
    {
        Task<Categorium> GetCategoriaById(int categoriaId, CancellationToken cancellationToken);
        Task<List<Categorium>> GetAllCategorias(CancellationToken cancellationToken);
        Task<Categorium> CreateCategoria(Categorium categoria, CancellationToken cancellationToken);
    }
}
