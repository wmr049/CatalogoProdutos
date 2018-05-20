using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Eventos
{
    public class RegistradoProdutoEvento : BaseProdutoEvento
    {
        public RegistradoProdutoEvento(            
            Guid id,
            string nome,
            decimal preco,
            int codigo)
        {            
            Id = id;
            Nome = nome;
            Preco = preco;
            Codigo = codigo;

            AgregacaoId = id;
        }
    }
}
