using MediatR;
using System;

namespace CatalogoProdutos.Domain.Core.Eventos
{
    public abstract class Mensagem : INotification
    {
        public Mensagem()
        {
            TipoMensagem = GetType().Name;
        }

        public string TipoMensagem { get; protected set; }
        public Guid AgregacaoId { get; protected set; }
    }
}
