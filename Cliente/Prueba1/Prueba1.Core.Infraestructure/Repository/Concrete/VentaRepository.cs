using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class VentaRepository : IBaseRepository<Venta, int>
    {
        private CaprichoDB db;
        public VentaRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Venta Create(Venta venta)
        {
            venta.Fecha_registro = DateTime.Now;
            db.Ventas.Add(venta);
            return venta;
        }

        public void Delete(int entityId)
        {
            var selectedVenta = db.Ventas
               .Where(v => v.VentaId == entityId).FirstOrDefault();

            if (selectedVenta != null)
                db.Ventas.Remove(selectedVenta);
        }

        public List<Venta> GetAll()
        {
            return db.Ventas.ToList();
        }

        public Venta GetById(int entityId)
        {
            var selectedVenta = db.Ventas
                .Where(v => v.VentaId == entityId).FirstOrDefault();
            return selectedVenta;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Venta Update(Venta entity)
        {
            var selectedVenta = db.Ventas
               .Where(v => v.VentaId == entity.VentaId)
               .FirstOrDefault();

            if (selectedVenta != null)
            {
                selectedVenta.Municipio = entity.Municipio;
                selectedVenta.MTotal = entity.MTotal;
                db.Entry(selectedVenta).State =
                  Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedVenta;
        }
    }
}

