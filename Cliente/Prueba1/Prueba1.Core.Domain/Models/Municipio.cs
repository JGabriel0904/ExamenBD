using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }
        [ForeignKey("DepartamentoId")]
        public int DepartamentoId { get; set; }
    }
}
