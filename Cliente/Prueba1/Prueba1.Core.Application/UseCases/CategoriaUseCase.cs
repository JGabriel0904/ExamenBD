using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class CategoriaUseCase : IBaseUseCase<Categoria, int>
    {
        private readonly IBaseRepository<Categoria, int> repository;

        public CategoriaUseCase(IBaseRepository<Categoria, int> repository)
        {
            this.repository = repository;
        }

        public Categoria Create(Categoria entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La categoria no puede ser nula");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Categoria> GetAll()
        {
            return repository.GetAll();
        }

        public Categoria GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Categoria Update(Categoria entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}