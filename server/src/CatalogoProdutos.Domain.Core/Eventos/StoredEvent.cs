using System;

namespace CatalogoProdutos.Domain.Core.Eventos
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event evento, string data, string user)
        {
            Id = Guid.NewGuid();
            AgregacaoId = evento.AgregacaoId;
            TipoMensagem = evento.TipoMensagem;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
