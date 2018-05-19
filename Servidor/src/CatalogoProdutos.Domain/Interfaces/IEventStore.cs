using CatalogoProdutos.Domain.Core.Eventos;

namespace CatalogoProdutos.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
