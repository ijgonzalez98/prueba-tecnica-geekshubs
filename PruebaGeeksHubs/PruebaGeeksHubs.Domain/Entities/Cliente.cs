using System;
using System.Collections.Generic;

namespace PruebaGeeksHubs.Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
