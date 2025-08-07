using GPBA.Application.Features;
using GPBA.Infrastructure.Dapper;
using GPBA.Infrastructure.DbContexts;
using GPBA.Infrastructure.Providers;
using GPBA.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPBA.Infrastructure;

/// <summary>
/// Добавление сервисов в DI
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Сервисы слоя инфраструктуры приложения
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDataStorages()
            .AddRepositories()
            .AddSingleton<DapperContext>();

        return services;
    }

    /// <summary>
    /// Сервисы работы с базой данных
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddDataStorages(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ApplicationDbContext>();

        return services;
    }

    /// <summary>
    /// Сервисы репозиториев
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        return services;
    }
}
