using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class ClienteRepository : IBaseRepository<Cliente, int>
    {
        private CaprichoDB db;
        public ClienteRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Cliente Create(Cliente cliente)
        {
            cliente.Fecha_registro = DateTime.Now;
            db.Clientes.Add(cliente);
            return cliente;
        }

        public void Delete(int entityId)
        {
            var selectedCliente = db.Clientes
               .Where(cli => cli.ClienteId == entityId).FirstOrDefault();

            if (selectedCliente != null)
                db.Clientes.Remove(selectedCliente);
        }

        public List<Cliente> GetAll()
        {
            return db.Clientes.ToList();
        }

        public Cliente GetById(int entityId)
        {
            var selectedCliente = db.Clientes
                .Where(cli => cli.ClienteId == entityId).FirstOrDefault();
            return selectedCliente;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Cliente Update(Cliente entity)
        {
            var selectedCliente = db.Clientes
               .Where(cli => cli.ClienteId == entity.ClienteId)
               .FirstOrDefault();

            if (selectedCliente != null)
            {
                selectedCliente.ClienteNombre = entity.ClienteNombre;
                selectedCliente.Correo = entity.Correo;
                selectedCliente.Clave = entity.Clave;
                db.Entry(selectedCliente).State =
                  Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedCliente;
        }
    }
}
