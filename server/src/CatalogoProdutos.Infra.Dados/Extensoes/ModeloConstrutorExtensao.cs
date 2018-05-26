using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Infra.Dados.Extensoes
{
    public static class ModeloConstrutorExtensao
    {
        public static void AdicionarConfiguracao<TEntity>(this ModelBuilder modelBuilder,
            EntidadeTipoConfiguracao<TEntity> configuracao) where TEntity : class
        {
            configuracao.Mapa(modelBuilder.Entity<TEntity>());
        }
    }
}
