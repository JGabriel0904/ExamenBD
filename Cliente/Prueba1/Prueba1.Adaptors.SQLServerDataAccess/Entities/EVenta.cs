using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Core.Domain.Models;

namespace Prueba1.Adaptors.SQLServerDataAccess.Entities
{
    public class EVenta : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tb_venta");

            builder.HasKey(v => v.VentaId);

            builder
                .HasMany(v => v.Carritos)
                .WithOne(car => car.Venta);

        }
    }
}

