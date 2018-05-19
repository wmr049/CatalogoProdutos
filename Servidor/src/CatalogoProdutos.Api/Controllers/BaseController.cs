using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CatalogoProdutos.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly ManipuladorNotificacaoDominio _notifications;
        private readonly IMediatorHandler _mediator;

        protected Guid OrganizadorId { get; set; }

        protected BaseController(INotificationHandler<NotificacaoDominio> notifications,
                                IUsuario user,
                                IMediatorHandler mediator)
        {
            _notifications = (ManipuladorNotificacaoDominio)notifications;
            _mediator = mediator;

            if (user.EstaAutenticado())
            {
                OrganizadorId = user.BuscarIdUsuario();
            }

        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.BuscarNotificacoes().Select(n => n.Valor)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.TemNotificacoes());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new NotificacaoDominio(codigo, mensagem));
        }


        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotificarErro(result.ToString(), error.Description);
            }
        }

    }
}
