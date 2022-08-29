using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface ICategoriasRepository
    {
        Task<Categorium> GetCategoriaById(int categoriaId, CancellationToken cancellationToken);
    }
}
