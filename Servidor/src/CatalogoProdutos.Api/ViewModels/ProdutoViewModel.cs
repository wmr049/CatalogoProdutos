using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Api.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Descricao do Produto")]
        public string Descricao { get; set; }

        [Display(Name = "Código do Produto")]
        public int Codigo { get; set; }

        [Display(Name = "Preço'")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        public decimal Preco { get; set; }
    }
}
