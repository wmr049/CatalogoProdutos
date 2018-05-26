using CatalogoProdutos.Domain.Core.Comandos;
using CatalogoProdutos.Domain.Core.Eventos;

namespace CatalogoProdutos.Domain.Core.Bus
{
    public interface IBus
    {
        void EnviarComando<T>(T oComando) where T : Comando;
        void LancarEvento<T>(T oEvento) where T : Event;
    }
}
