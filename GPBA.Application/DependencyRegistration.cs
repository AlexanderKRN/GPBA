using GPBA.Application.Features.Offers.GetOffers;
using GPBA.Application.Features.Suppliers.CreateSupplier;
using GPBA.Application.Features.Suppliers.CreateSupplierOffer;
using GPBA.Application.Features.Suppliers.GetSuppliers;
using Microsoft.Extensions.DependencyInjection;

namespace GPBA.Application;

/// <summary>
/// Добавление сервисов в DI
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Сервисы слоя бизнес-логики приложения
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHandlers();

        return services;
    }

    /// <summary>
    /// Сервисы обработчиков
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<GetOffersHandler>();
        services.AddScoped<GetSuppliersHandler>();
        services.AddScoped<CreateSupplierHandler>();
        services.AddScoped<CreateSupplierOfferHandler>();

        return services;
    }
}
