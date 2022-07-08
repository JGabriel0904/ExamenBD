using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Models;
using Prueba1.Core.Application.Interfaces;

using Prueba1.Core.Infraestructure.Repository.Abstract;

namespace Prueba1.Core.Application.UseCases
{
    public class MunicipioUseCase : IBaseUseCase<Municipio, int>
    {
        private readonly IBaseRepository<Municipio, int> repository;

        public MunicipioUseCase(IBaseRepository<Municipio, int> repository)
        {
            this.repository = repository;
        }

        public Municipio Create(Municipio entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El municipio no puede ser nulo");
        }

        public void Delete(int entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Municipio> GetAll()
        {
            return repository.GetAll();
        }

        public Municipio GetById(int entityId)
        {
            return repository.GetById(entityId);
        }

        public Municipio Update(Municipio entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}