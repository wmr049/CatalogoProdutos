using AutoMapper;
using CatalogoProdutos.Api.ViewModels;
using CatalogoProdutos.Domain.Produtos;

namespace CatalogoProdutos.Api.AutoMapper
{
    public partial class AutoMapperConfiguracao
    {
        public class DominioParaViewModelMapeamentoPerfil : Profile
        {
            public DominioParaViewModelMapeamentoPerfil()
            {
                CreateMap<Produto, ProdutoViewModel>();                
            }
        }
    }
}
