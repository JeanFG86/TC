using TC.Busines.Interfaces;
using TC.Busines.Notificacoes;
using TC.Busines.Services;
using TC.Data.Context;
using TC.Data.Repository;
using TC.Data.UnitOfWork;

namespace TC.Api.Configs;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Data
        services.AddScoped<MeuDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();

        // Business
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<INotificador, Notificador>();

        return services;

    }
}
