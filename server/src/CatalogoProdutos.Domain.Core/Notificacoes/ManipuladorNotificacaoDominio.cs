using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.Domain.Core.Notificacoes
{
    public class ManipuladorNotificacaoDominio : INotificationHandler<NotificacaoDominio>
    {
        private List<NotificacaoDominio> _notificacoes;

        public ManipuladorNotificacaoDominio()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }

        public virtual List<NotificacaoDominio> BuscarNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(NotificacaoDominio mensagem)
        {
            _notificacoes.Add(mensagem);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: {mensagem.Chave} - {mensagem.Valor}");

        }

        public virtual bool TemNotificacoes()
        {
            return _notificacoes.Any();
        }

        public void Dispose()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }
    }
}
