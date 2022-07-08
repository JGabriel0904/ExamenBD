using System;
using System.Collections.Generic;
using System.Text;

using Prueba1.Core.Domain.Interfaces;

namespace Prueba1.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId> : ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);

        void Cancel(TransactionId transactionId);
    }
}


