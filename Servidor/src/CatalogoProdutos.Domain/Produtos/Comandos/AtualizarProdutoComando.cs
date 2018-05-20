using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Comandos
{
    public class AtualizarProdutoComando : BaseProdutoComando
    {
        public AtualizarProdutoComando(
            Guid id,
            string nome,
            string descricao,
            decimal preco
            )
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
    }
}
