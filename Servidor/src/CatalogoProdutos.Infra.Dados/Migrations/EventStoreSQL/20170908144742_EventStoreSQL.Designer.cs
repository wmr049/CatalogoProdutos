using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CatalogoProdutos.Infra.Dados.Contexto;

namespace CatalogoProdutos.Infra.Dados.Migrations.EventStoreSQL
{
    [DbContext(typeof(EventStoreSQLContext))]
    [Migration("20170908144742_EventStoreSQL")]
    partial class EventStoreSQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CatalogoProdutos.Domain.Core.Eventos.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AgregacaoId");

                    b.Property<string>("Data");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("CreationDate");

                    b.Property<string>("TipoMensagem")
                        .HasColumnName("Action")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("StoredEvent");
                });
        }
    }
}
