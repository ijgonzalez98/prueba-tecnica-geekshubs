using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;
using static PruebaGeeksHubs.Application.Features.Compras.Commands.CreateCompraByCliente.CreateCompraByClienteCommand;

namespace PruebaGeeksHubs.Application.Features.Compras.Commands.CreateCompraByCliente
{
    public class CreateCompraByClienteQueryHandler : IRequestHandler<CreateCompraByClienteCommand, CompraResponseDTO>
    {
        private readonly IComprasRepository _comprasRepository;
        private readonly IClientesRepository _clientesRepository;
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper _mapper;
        private readonly DateTime _date = DateTime.Now;

        public CreateCompraByClienteQueryHandler(
            IComprasRepository comprasRepository,
            IClientesRepository clientesRepository,
            IProductosRepository productosRepository,
            IMapper mapper)
        {
            _comprasRepository = comprasRepository;
            _clientesRepository = clientesRepository;
            _productosRepository = productosRepository;
            _mapper = mapper;
        }

        public async Task<CompraResponseDTO> Handle(CreateCompraByClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente cliente = await _clientesRepository.GetClienteById<Cliente>(request.ClienteId, cancellationToken);
            if (cliente == null) return null;

            if (!ValidaListaProductosAComprar(request.Data.Productos)) return null;

            List<CompraProducto> comprasProductos = await ProcesarCompraProductos(request, cancellationToken);
            if (comprasProductos == null) return null;

            Compra compra = MapCompra(request, comprasProductos);
            var response = _mapper.Map<CompraResponseDTO>(await _comprasRepository.CreateCompra(compra, cancellationToken));

            await ReducirStockProductos(request.Data.Productos, cancellationToken);

            return await Task.FromResult(response);
        }

        private async Task<List<CompraProducto>> ProcesarCompraProductos(CreateCompraByClienteCommand request, CancellationToken cancellationToken)
        {
            List<CompraProducto> compraProductoList = new();

            foreach (ProductoCantidad p in request.Data.Productos)
            {
                Producto producto = await _productosRepository.GetProductoById<Producto>(p.ProductoId, cancellationToken);
                if (producto == null || !ValidaStockDisponible(producto.Cantidad, p.Cantidad)) return null;

                CompraProducto compraProducto = MapCompraProducto(producto, p.Cantidad);
                compraProductoList.Add(compraProducto);
            }

            return await Task.FromResult(compraProductoList);
        }

        private static bool ValidaListaProductosAComprar(List<ProductoCantidad> productos)
        {
            if (productos.Count == 0) return false;
            if (ExistenProductosRepetidos(productos)) return false;

            return true;
        }

        private static bool ExistenProductosRepetidos(List<ProductoCantidad> productos)
        {
            List<int> ids = new();

            foreach (ProductoCantidad p in productos)
            {
                if (ids.Contains(p.ProductoId))
                {
                    return true;
                }
                else
                {
                    ids.Add(p.ProductoId);
                }
            }
            return false;
        }

        private static bool ValidaStockDisponible(int stock, int demanda)
        {
            return stock - demanda >= 0;
        }

        private static CompraProducto MapCompraProducto(Producto producto, int cantidad)
        {
            return new()
            {
                ProductoId = producto.ProductoId,
                Cantidad = cantidad,
                Total = producto.Precio * cantidad
            };
        }

        private Compra MapCompra(CreateCompraByClienteCommand request, List<CompraProducto> compraProductosList)
        {
            return new()
            {
                ClienteId = request.ClienteId,
                Fecha = _date,
                MetodoPago = request.Data.MetodoPago,
                Estado = "ACEPTADO",
                CompraProductos = compraProductosList
            };
        }

        private async Task ReducirStockProductos(List<ProductoCantidad> productoCantidadList, CancellationToken cancellationToken)
        {
            foreach (ProductoCantidad p in productoCantidadList)
            {
                Producto producto = await _productosRepository.GetProductoById<Producto>(p.ProductoId, cancellationToken);
                producto = MapNuevoStockProducto(producto, p.Cantidad);

                if (producto != null)
                {
                    _ = await _productosRepository.UpdateProducto(producto, cancellationToken);
                }
            }
        }

        private static Producto MapNuevoStockProducto(Producto producto, int demanda)
        {
            if (producto == null || !ValidaStockDisponible(producto.Cantidad, demanda)) return null;

            _ = producto.Cantidad -= demanda;
            return producto;
        }
    }
}
