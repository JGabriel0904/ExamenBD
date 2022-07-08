using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class MunicipioRepository : IBaseRepository<Municipio, int>
    {
        private CaprichoDB db;
        public MunicipioRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Municipio Create(Municipio municipio)
        {
            db.Municipios.Add(municipio);
            return municipio;
        }

        public void Delete(int entityId)
        {
            var selectedMunicipio = db.Municipios
               .Where(m => m.MunicipioId == entityId).FirstOrDefault();

            if (selectedMunicipio != null)
                db.Municipios.Remove(selectedMunicipio);
        }

        public List<Municipio> GetAll()
        {
            return db.Municipios.ToList();
        }

        public Municipio GetById(int entityId)
        {
            var selectedMunicipio = db.Municipios
                .Where(m => m.MunicipioId == entityId).FirstOrDefault();
            return selectedMunicipio;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Municipio Update(Municipio entity)
        {
            var selectedMunicipio = db.Municipios
               .Where(m => m.MunicipioId == entity.MunicipioId)
               .FirstOrDefault();

            if (selectedMunicipio != null)
            {
                selectedMunicipio.MunicipioNombre = entity.MunicipioNombre;
                db.Entry(selectedMunicipio).State =
                  Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedMunicipio ;
        }
    }
}
