namespace CatalogoProdutos.Domain.Core.Eventos
{
    public interface IManipulador<in T> where T : Mensagem
    {
        void Manipular(T mensagem);
    }
}
