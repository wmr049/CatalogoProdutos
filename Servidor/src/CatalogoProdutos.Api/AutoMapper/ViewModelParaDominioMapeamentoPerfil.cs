using AutoMapper;
using CatalogoProdutos.Api.ViewModels;
using CatalogoProdutos.Domain.Produtos.Comandos;

namespace CatalogoProdutos.Api.AutoMapper
{
    public partial class AutoMapperConfiguracao
    {
        public class ViewModelParaDominioMapeamentoPerfil : Profile
        {
            public ViewModelParaDominioMapeamentoPerfil()
            {
                CreateMap<ProdutoViewModel, RegistrarProdutoComando>()
                    .ConstructUsing(c => new RegistrarProdutoComando(c.Nome, c.Descricao, c.Preco));

                CreateMap<ProdutoViewModel, AtualizarProdutoComando>()
                    .ConstructUsing(c => new AtualizarProdutoComando(c.Id, c.Nome, c.Descricao, c.Preco));
                
                CreateMap<ProdutoViewModel, ExcluirProdutoComando>()
                    .ConstructUsing(c => new ExcluirProdutoComando(c.Id));                
                
            }
        }
    }
}
