using CSharpFunctionalExtensions;
using GPBA.Application.Dtos;
using GPBA.Domain.Common;
using GPBA.Domain.Entities;

namespace GPBA.Application.Features;
public interface ISupplierRepository
{
    /// <summary>
    /// Метод добавления поставщика
    /// </summary>
    /// <param name="supplier"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task Add(Supplier supplier, CancellationToken ct);

    /// <summary>
    /// Метод получения всех поставщиков
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IReadOnlyList<Supplier>> GetAll(CancellationToken ct);

    /// <summary>
    /// Метод получения поставщика по ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Result<Supplier, Error>> GetById(int id, CancellationToken ct);

    /// <summary>
    /// Метод получения топ-3 популярных поставщиков
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IReadOnlyList<SupplierDto>> GetMostPopular(CancellationToken ct);

    /// <summary>
    /// Метод получения всех офферов
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IReadOnlyList<Offer>> GetOffers(CancellationToken ct);
}