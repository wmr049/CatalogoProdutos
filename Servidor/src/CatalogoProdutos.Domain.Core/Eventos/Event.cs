using System;

namespace CatalogoProdutos.Domain.Core.Eventos
{
    public abstract class Event : Mensagem
    {
        
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }

    }
}
