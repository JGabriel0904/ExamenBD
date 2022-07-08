using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha_registro { get; set; }
        public string PhotoFileName { get; set; }
        public List<Carrito> Carritos { get; set; }
    }
}
