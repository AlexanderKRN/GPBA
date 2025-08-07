using CSharpFunctionalExtensions;
using GPBA.Domain.Common;

namespace GPBA.Domain.Entities;

/// <summary>
/// Сущность оффера
/// </summary>
public class Offer
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Бренд
    /// </summary>
    public string Brand { get; private set; } = null!;

    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; private set; } = null!;

    /// <summary>
    /// Уникальный идентификатор поставщика
    /// </summary>
    public int SupplierId { get; }

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    private Offer()
    {
    }

    private Offer(string brand, string model)
    {
        Brand = brand;
        Model = model;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Метод создания оффера
    /// </summary>
    /// <param name="brand"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public static Result<Offer, Error> Create(
        string brand,
        string model)
    {
        brand = brand.Trim();
        if (brand.IsEmpty() || brand.Length > Constraints.SHORT_FIELD_LENGTH)
            return ErrorList.General.ValueIsInvalid();

        model = model.Trim();
        if (model.IsEmpty() || brand.Length > Constraints.SHORT_FIELD_LENGTH)
            return ErrorList.General.ValueIsInvalid();

        return new Offer(brand, model);
    }
}
