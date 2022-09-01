namespace PruebaGeeksHubs.Application.DTOs.Responses
{
    public class ProductoResponseDTO
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
