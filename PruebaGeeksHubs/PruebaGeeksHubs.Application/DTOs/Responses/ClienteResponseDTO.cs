namespace PruebaGeeksHubs.Application.DTOs.Responses
{
    public class ClienteResponseDTO
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
    }
}
