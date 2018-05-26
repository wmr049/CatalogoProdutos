using CatalogoProdutos.Domain.Core.Eventos;
using System;

namespace CatalogoProdutos.Domain.Core.Comandos
{
    public class Comando : Mensagem
    {
        public Comando()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }

    }
}
