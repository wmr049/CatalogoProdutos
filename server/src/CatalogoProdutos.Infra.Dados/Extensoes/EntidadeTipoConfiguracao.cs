using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CatalogoProdutos.Infra.Dados.Extensoes
{
    public abstract class EntidadeTipoConfiguracao<TEntity> where TEntity : class
    {
        public abstract void Mapa(EntityTypeBuilder<TEntity> construtor);
    }
}
