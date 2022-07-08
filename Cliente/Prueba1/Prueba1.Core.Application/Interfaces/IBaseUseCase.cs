using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Interfaces;

namespace Prueba1.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {
    }
}

