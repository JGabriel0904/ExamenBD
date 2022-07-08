using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Interfaces;

namespace Prueba1.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}

