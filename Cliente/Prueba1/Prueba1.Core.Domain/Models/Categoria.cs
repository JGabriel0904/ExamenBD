using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prueba1.Core.Domain.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        
    }
}
