using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class VentaUseCase : IBaseUseCase<Venta, int>
    {
        private readonly IBaseRepository<Venta, int> repository;

        public VentaUseCase(IBaseRepository<Venta, int> repository)
        {
            this.repository = repository;
        }

        public Venta Create(Venta entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La venta no puede ser nula");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Venta> GetAll()
        {
            return repository.GetAll();
        }

        public Venta GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Venta Update(Venta entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
