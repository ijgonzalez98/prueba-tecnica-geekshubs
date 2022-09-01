using System;
using System.Collections.Generic;

namespace PruebaGeeksHubs.Domain.Entities
{
    public partial class CompraProducto
    {
        public int CompraProductoId { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public virtual Compra Compra { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
