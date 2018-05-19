using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CatalogoProdutos.Domain.Interfaces
{
    public interface IUsuario
    {
        string Nome { get; }
        Guid BuscarIdUsuario();
        bool EstaAutenticado();
        IEnumerable<Claim> BuscarClaimsIdentity();
    }
}
