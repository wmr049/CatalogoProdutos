using CatalogoProdutos.Domain.Produtos;
using CatalogoProdutos.Domain.Produtos.Repositorios;
using CatalogoProdutos.Infra.Dados.Contexto;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CatalogoProdutos.Infra.Dados.Repositorio
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(DefaultContext contexto) : base(contexto)
        {
        }


        public override IEnumerable<Produto> BuscarTodos()
        {
            var sql = "SELECT * FROM PRODUTOS P " +
                      "WHERE P.EXCLUIDO = 0 " +
                      "ORDER BY P.CODIGO ASC";

            return Db.Database.GetDbConnection().Query<Produto>(sql);
        }                
    }
}
