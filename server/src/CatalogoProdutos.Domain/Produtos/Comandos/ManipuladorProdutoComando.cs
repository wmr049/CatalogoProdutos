using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Domain.ManipuladoresComando;
using CatalogoProdutos.Domain.Produtos.Eventos;
using CatalogoProdutos.Domain.Produtos.Repositorios;
using MediatR;
using System;

namespace CatalogoProdutos.Domain.Produtos.Comandos
{
    public class ManipuladorProdutoComando : ManipuladorComando,
        INotificationHandler<RegistrarProdutoComando>,
        INotificationHandler<ExcluirProdutoComando>,
        INotificationHandler<AtualizarProdutoComando>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IUsuario _user;
        private readonly IMediatorHandler _mediator;

        public ManipuladorProdutoComando(IProdutoRepositorio produtoRepositorio,
            IUnidadeDeTrabalho unidadeDeTrabalho, 
            IMediatorHandler mediator, 
            INotificationHandler<NotificacaoDominio> notificacoes,
            IUsuario user) : base(unidadeDeTrabalho, mediator, notificacoes)
        {
            _produtoRepositorio = produtoRepositorio;
            _mediator = mediator;
            _user = user;
        }        

        public void Handle(RegistrarProdutoComando mensagem)
        {
            var produto = Produto.FabricaProduto.NovoProdutoCompleto(mensagem.Id, mensagem.Nome, mensagem.Descricao,
                mensagem.Preco);

            if (!ProdutoValido(produto))
            {
                return;
            }

            // TODO:
            //Validações de Negocio !            

            //Persistencia
            _produtoRepositorio.Adicionar(produto);

            if (Commit())
            {                
                Console.WriteLine("Produto registrado com sucesso");
                _mediator.PublicarEvento(new RegistradoProdutoEvento(produto.Id, produto.Nome, produto.Preco, produto.Codigo));
            }
        }

        public void Handle(ExcluirProdutoComando mensagem)
        {
            if (!ProdutoExistente(mensagem.Id, mensagem.TipoMensagem)) return;
            var produtoAtual = _produtoRepositorio.BuscarPorId(mensagem.Id);
            

            produtoAtual.ExcluirProduto();
            _produtoRepositorio.Atualizar(produtoAtual);

            if (Commit())
            {
                _mediator.PublicarEvento(new ExcluidoProdutoEvento(mensagem.Id));
            }
        }

        public void Handle(AtualizarProdutoComando mensagem)
        {
            var produtoAtual = _produtoRepositorio.BuscarPorId(mensagem.Id);

            if (!ProdutoExistente(mensagem.Id, mensagem.TipoMensagem)) return;

            var produto = Produto.FabricaProduto.NovoProdutoCompleto(mensagem.Id, mensagem.Nome, mensagem.Descricao,
                mensagem.Preco);            

            if (!ProdutoValido(produto)) return;

            _produtoRepositorio.Atualizar(produto);

            if (Commit())
            {
                _mediator.PublicarEvento(new AtualizadoProdutoEvento(produto.Id, produto.Nome, produto.Descricao,
                    produto.Preco));
            }
        }

        public bool ProdutoValido(Produto produto)
        {
            if (produto.EhValido()) return true;

            NotificarValidacoesErro(produto.ValidationResult);
            return false;
        }

        public bool ProdutoExistente(Guid id, string messageType)
        {
            var produto = _produtoRepositorio.BuscarPorId(id);

            if (produto != null) return true;
            _mediator.PublicarEvento(new NotificacaoDominio(messageType, "Produto não encontrado"));
            return false;
        }
    }
}
