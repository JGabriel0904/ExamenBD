using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string DepartamentoNombre { get; set; }

        public List<Municipio> Municipios { get; set; }
    }
}
