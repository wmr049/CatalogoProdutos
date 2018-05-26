using CatalogoProdutos.Domain.Core.Eventos;
using System;

namespace CatalogoProdutos.Domain.Core.Notificacoes
{
    public class NotificacaoDominio : Event
    {
        public Guid NotificacaoDominioId { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public NotificacaoDominio(string chave, string valor)
        {
            NotificacaoDominioId = Guid.NewGuid();
            Chave = chave;
            Valor = valor;
            Versao = 1;
        }

    }
}
