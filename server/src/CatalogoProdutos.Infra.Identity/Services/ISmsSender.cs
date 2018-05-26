using System.Threading.Tasks;

namespace CatalogoProdutos.Infra.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
