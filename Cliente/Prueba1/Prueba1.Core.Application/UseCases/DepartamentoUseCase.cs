using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class DepartamentoUseCase : IBaseUseCase<Departamento, int>
    {
        private readonly IBaseRepository<Departamento, int> repository;

        public DepartamentoUseCase(IBaseRepository<Departamento, int> repository)
        {
            this.repository = repository;
        }

        public Departamento Create(Departamento entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El departamento no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Departamento> GetAll()
        {
            return repository.GetAll();
        }

        public Departamento GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Departamento Update(Departamento entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}

