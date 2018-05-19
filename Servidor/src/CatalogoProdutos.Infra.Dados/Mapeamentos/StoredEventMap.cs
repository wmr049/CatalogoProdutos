using CatalogoProdutos.Domain.Core.Eventos;
using CatalogoProdutos.Infra.Dados.Extensoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CatalogoProdutos.Infra.Dados.Mapeamentos
{
    public class StoredEventMap : EntidadeTipoConfiguracao<StoredEvent>
    {
        public override void Mapa(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.TipoMensagem)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");

        }
    }
}
