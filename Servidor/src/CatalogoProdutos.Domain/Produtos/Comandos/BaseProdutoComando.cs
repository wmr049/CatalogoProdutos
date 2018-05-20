using CatalogoProdutos.Domain.Core.Comandos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Comandos
{
    public abstract class BaseProdutoComando : Comando{
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public decimal Preco { get; protected set; }

    }
}
