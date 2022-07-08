using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Administrador
    {
        public int AdministradorId { get; set; }
        public string AdministradorNombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
