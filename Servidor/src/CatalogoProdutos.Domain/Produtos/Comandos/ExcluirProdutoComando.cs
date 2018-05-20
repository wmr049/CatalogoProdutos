using System;

namespace CatalogoProdutos.Domain.Produtos.Comandos
{
    public class ExcluirProdutoComando : BaseProdutoComando
    {
        public ExcluirProdutoComando(Guid id)
        {
            Id = id;
            AgregacaoId = Id;
        }
    }
}
