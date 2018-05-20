using AutoMapper;
using CatalogoProdutos.Api.ViewModels;
using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Domain.Produtos.Comandos;
using CatalogoProdutos.Domain.Produtos.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CatalogoProdutos.Api.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoController(INotificationHandler<NotificacaoDominio> notifications,
            IUsuario user,
            IProdutoRepositorio produtoRepository,
            IMapper mapper,
            IMediatorHandler mediator) : base(notifications, user, mediator)
        {
            _mapper = mapper;
            _produtoRepositorio = produtoRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("produtos")]
        [Authorize(Policy = "PodeLerProdutos")]
        public IEnumerable<ProdutoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepositorio.BuscarTodos());
        }

        [HttpPost]
        [Route("produtos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Post([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var eventoCommand = _mapper.Map<RegistrarProdutoComando>(produtoViewModel);

            _mediator.EnviarComando(eventoCommand);
            return Response(eventoCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }

    }
}
