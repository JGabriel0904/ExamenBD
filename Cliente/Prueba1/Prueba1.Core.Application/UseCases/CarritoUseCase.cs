using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class CarritoUseCase : IBaseUseCase<Carrito, int>
    {
        private readonly IBaseRepository<Carrito, int> repository;

        public CarritoUseCase(IBaseRepository<Carrito, int> repository)
        {
            this.repository = repository;
        }

        public Carrito Create(Carrito entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El carrito no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Carrito> GetAll()
        {
            return repository.GetAll();
        }

        public Carrito GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Carrito Update(Carrito entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
