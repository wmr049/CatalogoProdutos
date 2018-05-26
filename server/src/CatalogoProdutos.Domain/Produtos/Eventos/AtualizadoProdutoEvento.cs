using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Eventos
{
    public class AtualizadoProdutoEvento : BaseProdutoEvento
    {
        public AtualizadoProdutoEvento(Guid id,
            string descricao,
            string nome,
            decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;

            AgregacaoId = id;
        }
}
}
