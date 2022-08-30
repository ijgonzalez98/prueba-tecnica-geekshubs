using System;
using System.Collections.Generic;

namespace PruebaGeeksHubs.Domain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            CompraProductos = new HashSet<CompraProducto>();
        }

        public int ProductoId { get; set; }
        public int? CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Categorium? Categoria { get; set; }
        public virtual ICollection<CompraProducto> CompraProductos { get; set; }
    }
}
