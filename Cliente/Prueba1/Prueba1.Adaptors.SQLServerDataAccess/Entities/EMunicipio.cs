using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Core.Domain.Models;

namespace Prueba1.Adaptors.SQLServerDataAccess.Entities
{
    public class EMunicipio : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("tb_municipio");

            builder.HasKey(m => m.MunicipioId);
        }
    }
}
