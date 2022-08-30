﻿using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Domain.Repositories
{
    public interface ICategoriasRepository
    {
        Task<T> GetCategoriaById<T>(int categoriaId, CancellationToken cancellationToken);
        Task<List<T>> GetAllCategorias<T>(CancellationToken cancellationToken);
        Task<Categorium> CreateCategoria(Categorium categoria, CancellationToken cancellationToken);
    }
}
