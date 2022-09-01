using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using System.ComponentModel.DataAnnotations;

namespace PruebaGeeksHubs.Application.Features.Compras.Commands.CreateCompraByCliente
{
    public class CreateCompraByClienteCommand : IRequest<CompraResponseDTO>
    {
        public int ClienteId { get; set; }
        public readonly CreateCompraByClienteRequestData Data;

        public CreateCompraByClienteCommand(int clienteId, CreateCompraByClienteRequestData data)
        {
            ClienteId = clienteId;
            Data = data;
        }

        public class CreateCompraByClienteRequestData
        {
            public string MetodoPago { get; set; } = null!;
            public List<ProductoCantidad> Productos { get; set; } = null!;
        }

        public class ProductoCantidad
        {
            public int ProductoId { get; set; }
            [Range(1, 15)]
            public int Cantidad { get; set; }
        }
    }
}
