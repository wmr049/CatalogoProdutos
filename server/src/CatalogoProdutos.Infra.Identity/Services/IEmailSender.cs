using System.Threading.Tasks;

namespace CatalogoProdutos.Infra.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
