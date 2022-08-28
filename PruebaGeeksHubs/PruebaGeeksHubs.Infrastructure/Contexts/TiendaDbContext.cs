using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaGeeksHubs.Domain.Entities;

namespace PruebaGeeksHubs.Infrastructure.Contexts
{
    public partial class TiendaDbContext : DbContext
    {
        public TiendaDbContext()
        {
        }

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<CompraProducto> CompraProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=prueba-tecnica-geekshubs; Trusted_Connection=True; Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__categori__DB875A4F0AB7F2DF");

                entity.ToTable("categoria");

                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.Property(e => e.CompraId).HasColumnName("compra_id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("metodo_pago");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__compra__cliente___2B3F6F97");
            });

            modelBuilder.Entity<CompraProducto>(entity =>
            {
                entity.ToTable("compra_producto");

                entity.Property(e => e.CompraProductoId).HasColumnName("compra_producto_id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CompraId).HasColumnName("compra_id");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.CompraProductos)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK__compra_pr__compr__2F10007B");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.CompraProductos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__compra_pr__produ__2E1BDC42");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__producto__catego__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
