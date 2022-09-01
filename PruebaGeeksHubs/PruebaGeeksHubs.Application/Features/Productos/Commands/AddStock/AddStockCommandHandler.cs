using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, ProductoResponseDTO>
    {
        private readonly IProductosRepository _repository;
        private readonly IMapper _mapper;

        public AddStockCommandHandler(IProductosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductoResponseDTO> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            Producto producto = await _repository.GetProductoById<Producto>(request.ProductoId, cancellationToken);

            if (producto == null) return null;

            producto.Cantidad += request.Cantidad;
            
            var response = _mapper.Map<ProductoResponseDTO>(await _repository.UpdateProducto(producto, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
