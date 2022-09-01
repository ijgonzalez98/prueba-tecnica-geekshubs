using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetProductosByCategoria
{
    public class GetProductosByCategoriaQueryHandler : IRequestHandler<GetProductosByCategoriaQuery, List<ProductoResponseDTO>>
    {
        private readonly IProductosRepository _repository;

        public GetProductosByCategoriaQueryHandler(IProductosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoResponseDTO>> Handle(GetProductosByCategoriaQuery request, CancellationToken cancellationToken)
        {
            List<ProductoResponseDTO> productos = await _repository.GetProductosByCategoria<ProductoResponseDTO>(request.CategoriaId, cancellationToken);

            return await Task.FromResult(productos);
        }
    }
}
