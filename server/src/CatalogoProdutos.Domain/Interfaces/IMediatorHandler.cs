using CatalogoProdutos.Domain.Core.Comandos;
using CatalogoProdutos.Domain.Core.Eventos;
using System.Threading.Tasks;

namespace CatalogoProdutos.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Comando;
    }
}
