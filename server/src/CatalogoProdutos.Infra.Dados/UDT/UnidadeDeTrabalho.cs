using CatalogoProdutos.Domain.Core.Comandos;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Infra.Dados.Contexto;

namespace CatalogoProdutos.Infra.Dados.UDT
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly DefaultContext _contexto;

        public UnidadeDeTrabalho(DefaultContext contexto)
        {
            _contexto = contexto;
        }

        public RespostaComando Commit()
        {
            var linhasAfetadas = _contexto.SaveChanges();
            return new RespostaComando(linhasAfetadas > 0);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
