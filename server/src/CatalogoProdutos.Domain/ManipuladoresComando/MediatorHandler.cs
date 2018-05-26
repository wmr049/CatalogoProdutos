using CatalogoProdutos.Domain.Core.Comandos;
using CatalogoProdutos.Domain.Core.Eventos;
using CatalogoProdutos.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace CatalogoProdutos.Domain.ManipuladoresComando
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MediatorHandler(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public Task EnviarComando<T>(T comando) where T : Comando
        {
            return Publicar(comando);
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            if (!evento.TipoMensagem.Equals("DomainNotification"))
                _eventStore?.SalvarEvento(evento);

            return Publicar(evento);
        }

        private Task Publicar<T>(T mensagem) where T : Mensagem
        {
            return _mediator.Publish(mensagem);
        }
    }
}
