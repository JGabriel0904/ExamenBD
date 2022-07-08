using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class AdministradorUseCase : IBaseUseCase<Administrador, int>
    {
        private readonly IBaseRepository<Administrador, int> repository;

        public AdministradorUseCase(IBaseRepository<Administrador, int> repository)
        {
            this.repository = repository;
        }

        public Administrador Create(Administrador entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El admin no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Administrador> GetAll()
        {
            return repository.GetAll();
        }

        public Administrador GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Administrador Update(Administrador entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
