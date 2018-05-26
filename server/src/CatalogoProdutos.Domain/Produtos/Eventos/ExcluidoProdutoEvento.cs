using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Eventos
{
    public class ExcluidoProdutoEvento : BaseProdutoEvento
    {
        public ExcluidoProdutoEvento(Guid id)
        {
            Id = id;
            AgregacaoId = id;
        }
    }
}
