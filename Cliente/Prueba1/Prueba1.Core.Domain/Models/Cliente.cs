using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public DateTime Fecha_registro { get; set; }
        
    }
}
