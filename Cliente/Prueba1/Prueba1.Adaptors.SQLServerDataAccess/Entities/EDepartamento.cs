using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Core.Domain.Models;

namespace Prueba1.Adaptors.SQLServerDataAccess.Entities
{
    public class EDepartamento : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("tb_departamento");

            builder.HasKey(d => d.DepartamentoId);
        }
    }
}

