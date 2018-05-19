using System;
using System.Security.Claims;

namespace CatalogoProdutos.Infra.Identity.Models
{
    public static class PrincpalExtensaoClaims
    {
        public static string BuscarIdUsuario(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}
