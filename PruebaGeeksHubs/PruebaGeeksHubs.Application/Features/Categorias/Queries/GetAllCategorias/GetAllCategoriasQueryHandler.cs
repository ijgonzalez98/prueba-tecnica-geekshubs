using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, List<CategoriaResponseDTO>>
    {
        private readonly ICategoriasRepository _repository;

        public GetAllCategoriasQueryHandler(ICategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaResponseDTO>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            List<CategoriaResponseDTO> categorias = await _repository.GetAllCategorias<CategoriaResponseDTO>(cancellationToken);

            return await Task.FromResult(categorias);
        }
    }
}
