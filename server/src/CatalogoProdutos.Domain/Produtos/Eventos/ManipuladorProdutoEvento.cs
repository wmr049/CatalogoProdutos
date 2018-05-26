using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Domain.Produtos.Eventos
{
    public class ManipuladorProdutoEvento :
        INotificationHandler<RegistradoProdutoEvento>,
        INotificationHandler<ExcluidoProdutoEvento>,
        INotificationHandler<AtualizadoProdutoEvento>
    {
        public void Handle(AtualizadoProdutoEvento notification)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Atualizado com Sucesso");
        }

        public void Handle(ExcluidoProdutoEvento notification)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Excluido com Sucesso");
        }

        public void Handle(RegistradoProdutoEvento notification)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Registrado com Sucesso");
        }
    }
}
