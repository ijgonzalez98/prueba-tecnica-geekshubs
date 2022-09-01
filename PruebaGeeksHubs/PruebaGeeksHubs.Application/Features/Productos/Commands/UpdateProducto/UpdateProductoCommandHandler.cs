using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, ProductoResponseDTO>
    {
        private readonly IProductosRepository _productosRepository;
        private readonly ICategoriasRepository _categoriasRepository;
        private readonly IMapper _mapper;

        public UpdateProductoCommandHandler(IProductosRepository productosRepository, ICategoriasRepository categoriasRepository, IMapper mapper)
        {
            _productosRepository = productosRepository;
            _categoriasRepository = categoriasRepository;
            _mapper = mapper;
        }

        public async Task<ProductoResponseDTO> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            Producto producto = await _productosRepository.GetProductoById<Producto>(request.ProductoId, cancellationToken);
            if (producto == null) return null;

            if (request.Data.CategoriaId != null)
            {
                Categorium categoria = await _categoriasRepository.GetCategoriaById<Categorium>((int)request.Data.CategoriaId, cancellationToken);
                if (categoria == null) return null;
            }

            producto.CategoriaId = request.Data.CategoriaId ?? producto.CategoriaId;
            producto.Nombre = request.Data.Nombre ?? producto.Nombre;
            producto.Precio = request.Data.Precio ?? producto.Precio;

            var response = _mapper.Map<ProductoResponseDTO>(await _productosRepository.UpdateProducto(producto, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
