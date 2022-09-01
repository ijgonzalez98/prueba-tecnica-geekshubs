using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ProductoResponseDTO>
    {
        private readonly IProductosRepository _productosRepository;
        private readonly ICategoriasRepository _categoriasRepository;
        private readonly IMapper _mapper;

        public CreateProductoCommandHandler(IProductosRepository productosRepository, ICategoriasRepository categoriaRepository, IMapper mapper)
        {
            _productosRepository = productosRepository;
            _categoriasRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<ProductoResponseDTO> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            Categorium categoria = await _categoriasRepository.GetCategoriaById<Categorium>(request.CategoriaId, cancellationToken);
            if (categoria == null) return null;

            Producto producto = new()
            {
                CategoriaId = request.CategoriaId,
                Nombre = request.Nombre,
                Precio = request.Precio,
                Cantidad = request.Cantidad
            };

            var response = _mapper.Map<ProductoResponseDTO>(await _productosRepository.CreateProducto(producto, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
