using AutoMapper;
using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Domain.ManipuladoresComando;
using CatalogoProdutos.Infra.AspNetFilters;
using CatalogoProdutos.Infra.Dados.Contexto;
using CatalogoProdutos.Infra.Dados.EventSourcing;
using CatalogoProdutos.Infra.Dados.Repositorio.EventSourcing;
using CatalogoProdutos.Infra.Identity.Models;
using CatalogoProdutos.Infra.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogoProdutos.IOC
{
    public class NativoInjetorBootStrapper
    {
        public static void RegistroServicos(IServiceCollection services)
        {
            //ASPNet            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Dominio - Eventos
            services.AddScoped<INotificationHandler<NotificacaoDominio>, ManipuladorNotificacaoDominio>();


            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();


            //Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUsuario, AspNetUsuario>();

            //Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLoger>, Logger<GlobalActionLoger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLoger>();
        }
    }
}
