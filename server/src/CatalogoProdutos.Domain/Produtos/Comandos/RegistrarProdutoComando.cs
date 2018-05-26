using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Comandos
{
    public class RegistrarProdutoComando : BaseProdutoComando
    {
        public RegistrarProdutoComando(            
            string nome,
            string descricao,
            decimal preco,
            int codigo
            )
        {            
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}
