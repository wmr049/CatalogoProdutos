using CatalogoProdutos.Domain.Core.Eventos;
using System;

namespace CatalogoProdutos.Domain.Produtos.Eventos
{
    public abstract class BaseProdutoEvento : Event
    {
        public int Codigo { get; protected set; }
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }        
        public decimal Preco { get; protected set; }
    }
}
