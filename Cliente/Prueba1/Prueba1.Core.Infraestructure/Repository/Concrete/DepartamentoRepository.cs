using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class DepartamentoRepository : IBaseRepository<Departamento, int>
    {
        private CaprichoDB db;
        public DepartamentoRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Departamento Create(Departamento departamento)
        {
            db.Departamentos.Add(departamento);
            return departamento;
        }

        public void Delete(int entityId)
        {
            var selectedDepartamento = db.Departamentos
               .Where(d => d.DepartamentoId == entityId).FirstOrDefault();

            if (selectedDepartamento != null)
                db.Departamentos.Remove(selectedDepartamento);
        }

        public List<Departamento> GetAll()
        {
            return db.Departamentos.ToList();
        }

        public Departamento GetById(int entityId)
        {
            var selectedDepartamento = db.Departamentos
                .Where(dep => dep.DepartamentoId == entityId).FirstOrDefault();
            return selectedDepartamento;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Departamento Update(Departamento entity)
        {
            var selectedDepartamento = db.Departamentos
               .Where(dep => dep.DepartamentoId == entity.DepartamentoId)
               .FirstOrDefault();

            if (selectedDepartamento != null)
            {
                selectedDepartamento.DepartamentoNombre = entity.DepartamentoNombre;
                db.Entry(selectedDepartamento).State =
                  Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedDepartamento;
        }
    }
}
