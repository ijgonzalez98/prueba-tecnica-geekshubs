﻿namespace PruebaGeeksHubs.Application.DTOs.Responses
{
    public class CategoriaResponseDTO
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
