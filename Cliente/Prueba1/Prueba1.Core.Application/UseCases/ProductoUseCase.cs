using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class ProductoUseCase : IBaseUseCase<Producto, int>
    {
        private readonly IBaseRepository<Producto, int> repository;

        public ProductoUseCase(IBaseRepository<Producto, int> repository)
        {
            this.repository = repository;
        }

        public Producto Create(Producto entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El producto no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Producto> GetAll()
        {
            return repository.GetAll();
        }

        public Producto GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Producto Update(Producto entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
