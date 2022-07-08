using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Prueba1.Core.Domain.Models;
using Prueba1.Adaptors.SQLServerDataAccess.Entities;
using Prueba1.Adaptors.SQLServerDataAccess.Utils;

namespace Prueba1.Adaptors.SQLServerDataAccess.Contexts
{
    public class CaprichoDB:DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ECategoria());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EProducto());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }
}
