using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaResponseDTO>
    {
        private readonly ICategoriasRepository _repository;

        public GetCategoriaByIdQueryHandler(ICategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaResponseDTO> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            CategoriaResponseDTO categoria = await _repository.GetCategoriaById<CategoriaResponseDTO>(request.CategoriaId, cancellationToken);

            if (categoria == null) throw new Exception("La categoría indicada no existe.");

            return await Task.FromResult(categoria);
        }
    }
}
