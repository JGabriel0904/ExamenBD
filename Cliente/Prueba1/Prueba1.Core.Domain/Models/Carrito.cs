using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        [ForeignKey("VentaId")]
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public decimal ProductoPrecio { get; set; }
        public int Cantidad { get; set; }
    }
}
