using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Infraestructure.Repository.Abstract;
using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Prueba1.Core.Infraestructure.Repository.Concrete
{
    public class CategoriaRepository : IBaseRepository<Categoria, int>
    {
        private CaprichoDB db;
        public CategoriaRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Categoria Create(Categoria categoria)
        {
            db.Categorias.Add(categoria);
            return categoria;
        }

        public void Delete(int entityId)
        {
            var selectedCategoria = db.Categorias
               .Where(cat => cat.CategoriaId == entityId).FirstOrDefault();

            if (selectedCategoria != null)
                db.Categorias.Remove(selectedCategoria);
        }

        public List<Categoria> GetAll()
        {
            return db.Categorias.ToList();
        }

        public Categoria GetById(int entityId)
        {
            var selectedCategoria = db.Categorias
                .Where(cat => cat.CategoriaId == entityId).FirstOrDefault();
            return selectedCategoria;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Categoria Update(Categoria entity)
        {
            var selectedCategoria = db.Categorias
               .Where(cat => cat.CategoriaId == entity.CategoriaId)
               .FirstOrDefault();

            if (selectedCategoria != null)
            {
                selectedCategoria.CategoriaNombre = entity.CategoriaNombre;
                db.Entry(selectedCategoria).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedCategoria;
        }
    }
}