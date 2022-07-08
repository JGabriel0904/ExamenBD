using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class AdministradorRepository : IBaseRepository<Administrador, int>
    {
        private CaprichoDB db;
        public AdministradorRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Administrador Create(Administrador administrador)
        {
            db.Administradores.Add(administrador);
            return administrador;
        }

        public void Delete(int entityId)
        {
            var selectedAdministrador = db.Administradores
               .Where(a => a.AdministradorId == entityId).FirstOrDefault();

            if (selectedAdministrador != null)
                db.Administradores.Remove(selectedAdministrador);
        }

        public List<Administrador> GetAll()
        {
            return db.Administradores.ToList();
        }

        public Administrador GetById(int entityId)
        {
            var selectedAdministrador = db.Administradores
                .Where(a => a.AdministradorId == entityId).FirstOrDefault();
            return selectedAdministrador;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Administrador Update(Administrador entity)
        {
            var selectedAdministrador = db.Administradores
               .Where(a => a.AdministradorId == entity.AdministradorId)
               .FirstOrDefault();

            if (selectedAdministrador != null)
            {
                selectedAdministrador.AdministradorNombre = entity.AdministradorNombre;
                selectedAdministrador.Correo = entity.Correo;
                selectedAdministrador.Clave = entity.Clave;
                  db.Entry(selectedAdministrador).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedAdministrador;
        }
    }
}
