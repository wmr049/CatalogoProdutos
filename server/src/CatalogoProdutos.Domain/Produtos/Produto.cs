using CatalogoProdutos.Domain.Core.Models;
using FluentValidation;
using System;

namespace CatalogoProdutos.Domain.Produtos
{
    public class Produto : Entity<Produto>
    {
        public Produto(string nome,
            string descricao,
            decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
        private Produto() { }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }        
        public decimal Preco { get; private set; }
        public bool Excluido { get; private set; }

        public void ExcluirProduto()
        {
            //TODO: Deve validar alguma regra?
            Excluido = true;

        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do produto precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do produto precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarValor()
        {
            RuleFor(c => c.Preco)
                    .ExclusiveBetween(1, 50000)
                    .WithMessage("Preço precisa estar entre 1.00 e 50.000");
        }

        public static class FabricaProduto
        {
            public static Produto NovoProdutoCompleto(Guid id, string nome, string descricao, decimal preco)
            {
                var produto = new Produto()
                {
                    Id = id,
                    Nome = nome,
                    Descricao = descricao,
                    Preco = preco
                };

                return produto;
            }
        }
    }
}
