using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class ProductoRepository : IBaseRepository<Producto, int>
    {
        private CaprichoDB db;
        public ProductoRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Producto Create(Producto producto)
        {
            producto.Fecha_registro = DateTime.Now;
            db.Productos.Add(producto);
            return producto;
        }

        public void Delete(int entityId)
        {
            var selectedProducto = db.Productos
               .Where(p => p.ProductoId == entityId).FirstOrDefault();
            
            if (selectedProducto != null)
                db.Productos.Remove(selectedProducto);
        }

        public List<Producto> GetAll()
        {
            return db.Productos.ToList();
        }

        public Producto GetById(int entityId)
        {
            var selectedProducto = db.Productos
                .Where(p => p.ProductoId == entityId).FirstOrDefault();
            return selectedProducto;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Producto Update(Producto entity)
        {
            var selectedProducto = db.Productos
               .Where(p => p.ProductoId == entity.ProductoId)
               .FirstOrDefault();
            
            if (selectedProducto != null)
            {
                selectedProducto.ProductoNombre = entity.ProductoNombre;
                selectedProducto.Categoria = entity.Categoria;
                selectedProducto.PhotoFileName = entity.PhotoFileName;
                selectedProducto.Precio = entity.Precio;
                db.Entry(selectedProducto).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedProducto;
        }
    }
}
