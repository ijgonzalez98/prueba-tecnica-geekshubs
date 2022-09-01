using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ProductoResponseDTO>
    {
        private readonly IProductosRepository _repository;

        public GetProductoByIdQueryHandler(IProductosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductoResponseDTO> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            ProductoResponseDTO producto = await _repository.GetProductoById<ProductoResponseDTO>(request.ProductoId, cancellationToken);

            return producto != null ? await Task.FromResult(producto) : null;
        }
    }
}
