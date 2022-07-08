using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class CarritoRepository : IBaseRepository<Carrito, int>
    {
        private CaprichoDB db;
        public CarritoRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Carrito Create(Carrito carrito)
        {
            db.Carritos.Add(carrito);
            return carrito;
        }

        public void Delete(int entityId)
        {
            var selectedCarrito = db.Carritos
               .Where(car => car.CarritoId == entityId).FirstOrDefault();

            if (selectedCarrito != null)
                db.Carritos.Remove(selectedCarrito);
        }

        public List<Carrito> GetAll()
        {
            return db.Carritos.ToList();
        }

        public Carrito GetById(int entityId)
        {
            var selectedCarrito = db.Carritos
                .Where(car => car.CarritoId == entityId).FirstOrDefault();
            return selectedCarrito;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Carrito Update(Carrito entity)
        {
            var selectedCarrito = db.Carritos
               .Where(car => car.CarritoId == entity.CarritoId)
               .FirstOrDefault();

            if (selectedCarrito != null)
            {
                selectedCarrito.ProductoPrecio = entity.ProductoPrecio;
                selectedCarrito.Cantidad = entity.Cantidad;
                db.Entry(selectedCarrito).State =
                  Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedCarrito;
        }
    }
}
