using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Application.DTOs.Responses
{
    public class CompraResponseDTO
    {
        public int CompraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string? MetodoPago { get; set; }
        public string? Estado { get; set; }
        public virtual ICollection<CompraProductoResponseDTO>? CompraProductos { get; set; }
    }
}
