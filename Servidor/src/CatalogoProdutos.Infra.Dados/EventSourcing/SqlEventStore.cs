using CatalogoProdutos.Domain.Core.Eventos;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Infra.Dados.Repositorio.EventSourcing;
using Newtonsoft.Json;

namespace CatalogoProdutos.Infra.Dados.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUsuario _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUsuario user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void SalvarEvento<T>(T evento) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(evento);

            var storedEvent = new StoredEvent(
                evento,
                serializedData,
                _user.BuscarIdUsuario().ToString());

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
