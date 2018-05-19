using CatalogoProdutos.Domain.Core.Comandos;
using System;

namespace CatalogoProdutos.Domain.Interfaces
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        RespostaComando Commit();
    }
}
