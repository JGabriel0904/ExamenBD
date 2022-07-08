using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Core.Domain.Models;

namespace Prueba1.Adaptors.SQLServerDataAccess.Entities
{
    public class ECarrito : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("tb_carrito");

            builder.HasKey(car => car.CarritoId);

            builder
                .HasOne(car => car.Producto)
                .WithMany(p => p.Carritos);

            builder
                .HasOne(car => car.Venta)
                .WithMany(v => v.Carritos);
        }
    }
}
