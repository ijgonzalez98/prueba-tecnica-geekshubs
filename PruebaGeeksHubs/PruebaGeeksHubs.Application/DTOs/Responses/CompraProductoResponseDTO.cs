namespace PruebaGeeksHubs.Application.DTOs.Responses
{
    public class CompraProductoResponseDTO
    {
        public int CompraProductoId { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
