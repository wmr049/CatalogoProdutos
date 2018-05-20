using CatalogoProdutos.Domain.Produtos;
using CatalogoProdutos.Infra.Dados.Extensoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProdutos.Infra.Dados.Mapeamentos
{
    public class ProdutoMapeamento : EntidadeTipoConfiguracao<Produto>
    {
        public override void Mapa(EntityTypeBuilder<Produto> construtor)
        {
            construtor
                .Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            construtor
                .Property(e => e.Descricao)
                .HasColumnType("varchar(150)");            

            construtor
                .Ignore(e => e.ValidationResult);
            
            construtor
                .Ignore(e => e.CascadeMode);

            construtor
                .ToTable("Produtos");
        }
    }
}
