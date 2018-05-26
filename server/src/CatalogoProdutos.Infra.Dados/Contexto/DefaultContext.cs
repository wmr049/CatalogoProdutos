using CatalogoProdutos.Domain.Produtos;
using CatalogoProdutos.Infra.Dados.Extensoes;
using CatalogoProdutos.Infra.Dados.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CatalogoProdutos.Infra.Dados.Contexto
{
    public class DefaultContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AdicionarConfiguracao(new ProdutoMapeamento());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
