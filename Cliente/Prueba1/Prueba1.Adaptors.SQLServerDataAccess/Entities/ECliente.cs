using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Core.Domain.Models;

namespace Prueba1.Adaptors.SQLServerDataAccess.Entities
{
    public class ECliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tb_cliente");

            builder.HasKey(cli => cli.ClienteId);


        }
    }
}

