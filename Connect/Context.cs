using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Evaluacion.Models;

namespace Evaluacion.Connect
{
    public class Context : DbContext
    {
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        public Context(DbContextOptions<Context> optionsContext) : base(optionsContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.HasKey(e => e.Id).HasName("PK_Categoria");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                   .HasColumnName("nombre")
                   .HasColumnType("varchar(255)");
                entity.Property(e => e.Observacion)
                   .HasColumnName("observacion")
                   .HasColumnType("varchar(500)");
                entity.Property(e => e.Activo)
                   .HasColumnName("active")
                   .HasColumnType("bit");

            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.HasKey(e => e.Id).HasName("PK_Marca");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                   .HasColumnName("nombre")
                   .HasColumnType("varchar(255)");
                entity.Property(e => e.Observacion)
                   .HasColumnName("observacion")
                   .HasColumnType("varchar(500)");
                entity.Property(e => e.Activo)
                   .HasColumnName("active")
                   .HasColumnType("bit");

            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.HasKey(e => e.Id).HasName("PK_Proveedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion")
                .HasColumnType("varchar(1)");

                entity.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion")
                .HasColumnType("varchar(1)");

                entity.Property(e => e.Nombre)
                  .HasColumnName("nombre")
                  .HasColumnType("varchar(255)");

                entity.Property(e => e.Identificacion)
                  .HasColumnName("identificacion")
                  .HasColumnType("varchar(255)");

                entity.Property(e => e.Direccion)
                .HasColumnName("direccion")
                .HasColumnType("varchar(500)");

                entity.Property(e => e.Telefono)
                   .HasColumnName("telefono")
                   .HasColumnType("varchar(255)");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Activo)
                    .HasColumnName("active")
                    .HasColumnType("bit");

            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.ToTable("historico");

                entity.HasKey(e => e.Id).HasName("PK_historico");

                entity.HasIndex(e => e.ProductoId)
               .HasDatabaseName("fk_historico_producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");
                 

                entity.Property(e => e.Accion)
                  .HasColumnName("accion")
                  .HasColumnType("varchar(255)");

                entity.Property(e => e.ValorAnterior)
                .HasColumnName("valor_anterior")
                .HasColumnType("varchar(1000)");

                entity.Property(e => e.ValorNuevo)
                   .HasColumnName("valor_nuevo")
                   .HasColumnType("varchar(1000)");

                entity.Property(e => e.fecha)
                   .HasColumnName("fecha")
                   .HasColumnType("datetime");

                entity.HasOne(p => p.Producto).WithMany(c => c.Historicos)
                .HasForeignKey(c => c.ProductoId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historico_producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.HasIndex(e => e.ProveedorId)
                .HasDatabaseName("fk_producto_proveedor");

                entity.HasIndex(e => e.CategoriaId)
                .HasDatabaseName("fk_producto_categoria");

                entity.HasIndex(e => e.MarcaId)
                .HasDatabaseName("fk_producto_marca");

                entity.HasKey(e => e.Id).HasName("PK_Producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
                entity.Property(e => e.CategoriaId ).HasColumnName("categoria_id");
                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.Property(e => e.CodigoBarras)
                  .HasColumnName("codigo_barras")
                  .HasColumnType("varchar(255)");

                entity.Property(e => e.Descripcion)
                  .HasColumnName("descripcion")
                  .HasColumnType("varchar(255)");

                entity.Property(e => e.Medidas)
                .HasColumnName("medidas")
                .HasColumnType("varchar(255)");

                entity.Property(e => e.Precio)
                   .HasColumnName("precio")
                   .HasColumnType("decimal(10,4)");

                entity.Property(e => e.Stock)
                  .HasColumnName("stock")
                  .HasColumnType("decimal(10,4)");

                entity.Property(e => e.Activo)
                 .HasColumnName("active")
                 .HasColumnType("bit");

                entity.HasOne(p => p.Categoria).WithMany(c => c.Productos)
                .HasForeignKey(c => c.CategoriaId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_Categoria");

                entity.HasOne(p => p.Proveedor).WithMany(c => c.Productos)
              .HasForeignKey(c => c.ProveedorId).OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_producto_proveedor");

                entity.HasOne(p => p.Marca).WithMany(c => c.Productos)
            .HasForeignKey(c => c.MarcaId).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_producto_Marca");

            });
        }
    }
}
