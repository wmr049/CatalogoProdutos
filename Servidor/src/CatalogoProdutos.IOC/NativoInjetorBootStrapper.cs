using AutoMapper;
using CatalogoProdutos.Domain.Core.Notificacoes;
using CatalogoProdutos.Domain.Produtos.Comandos;
using CatalogoProdutos.Domain.Produtos.Eventos;
using CatalogoProdutos.Domain.Produtos.Repositorios;
using CatalogoProdutos.Domain.Interfaces;
using CatalogoProdutos.Domain.ManipuladoresComando;

using CatalogoProdutos.Infra.Dados.Contexto;
using CatalogoProdutos.Infra.Dados.EventSourcing;
using CatalogoProdutos.Infra.Dados.Repositorio;
using CatalogoProdutos.Infra.Dados.Repositorio.EventSourcing;
using CatalogoProdutos.Infra.Dados.UDT;
using CatalogoProdutos.Infra.AspNetFilters;
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

            //Dominio - Comandos
            services.AddScoped<INotificationHandler<RegistrarProdutoComando>, ManipuladorProdutoComando>();
            services.AddScoped<INotificationHandler<AtualizarProdutoComando>, ManipuladorProdutoComando>();
            services.AddScoped<INotificationHandler<ExcluirProdutoComando>, ManipuladorProdutoComando>();

            //Dominio - Eventos
            services.AddScoped<INotificationHandler<NotificacaoDominio>, ManipuladorNotificacaoDominio>();
            services.AddScoped<INotificationHandler<RegistradoProdutoEvento>, ManipuladorProdutoEvento>();
            services.AddScoped<INotificationHandler<AtualizadoProdutoEvento>, ManipuladorProdutoEvento>();
            services.AddScoped<INotificationHandler<ExcluidoProdutoEvento>, ManipuladorProdutoEvento>();

            //Infra - Dados
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            services.AddScoped<DefaultContext>();

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
