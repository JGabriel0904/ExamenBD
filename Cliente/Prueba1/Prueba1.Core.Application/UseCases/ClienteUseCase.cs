using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class ClienteUseCase : IBaseUseCase<Cliente, int>
    {
        private readonly IBaseRepository<Cliente, int> repository;

        public ClienteUseCase(IBaseRepository<Cliente, int> repository)
        {
            this.repository = repository;
        }

        public Cliente Create(Cliente entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El cliente no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Cliente> GetAll()
        {
            return repository.GetAll();
        }

        public Cliente GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Cliente Update(Cliente entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
