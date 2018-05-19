using CatalogoProdutos.Domain.Core.Eventos;
using System;
using System.Collections.Generic;

namespace CatalogoProdutos.Infra.Dados.Repositorio.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
