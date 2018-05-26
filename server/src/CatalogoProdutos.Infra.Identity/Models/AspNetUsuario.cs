using CatalogoProdutos.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CatalogoProdutos.Infra.Identity.Models
{
    public class AspNetUsuario : IUsuario
    {
        private IHttpContextAccessor _accessor;

        public AspNetUsuario(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Nome => _accessor.HttpContext.User.Identity.Name;
        public Guid BuscarIdUsuario()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.BuscarIdUsuario()) : Guid.NewGuid();
        }

        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> BuscarClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
