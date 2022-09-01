using System;
using System.Collections.Generic;

namespace PruebaGeeksHubs.Domain.Entities
{
    public partial class Compra
    {
        public Compra()
        {
            CompraProductos = new HashSet<CompraProducto>();
        }

        public int CompraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string? MetodoPago { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<CompraProducto> CompraProductos { get; set; }
    }
}
