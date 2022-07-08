using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba1.Core.Domain.Interfaces
{
    public interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}
