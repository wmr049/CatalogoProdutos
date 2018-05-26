using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Interfaces;
using FluentValidation.Results;
using System;
using MediatR;

namespace CatalogoProdutos.Domain.ManipuladoresComando
{
    public abstract class ManipuladorComando
    {

        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IMediatorHandler _mediator;
        private readonly ManipuladorNotificacaoDominio _notificacoes;

        public ManipuladorComando(IUnidadeDeTrabalho unidadeDeTrabalho, 
                                    IMediatorHandler mediator,
                                    INotificationHandler<NotificacaoDominio> notificacoes)
        {
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _mediator = mediator;
            _notificacoes = (ManipuladorNotificacaoDominio)notificacoes;            
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Console.WriteLine(erro.ErrorMessage);
                _mediator.PublicarEvento(new NotificacaoDominio(erro.PropertyName, erro.ErrorMessage));
            }
        }

        protected bool Commit()
        {

            if (_notificacoes.TemNotificacoes()) return false;            

            var respostaComando = _unidadeDeTrabalho.Commit();
            if (respostaComando.Sucesso) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            _mediator.PublicarEvento(new NotificacaoDominio("Commit", "Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }

    }
}
