namespace PruebaGeeksHubs.Application.DTOs.Requests
{
    public class UpdateClienteDTO
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
    }
}
