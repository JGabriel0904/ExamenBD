using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Interfaces;

namespace Prueba1.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {

    }
}


