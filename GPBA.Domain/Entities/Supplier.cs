using CSharpFunctionalExtensions;
using GPBA.Domain.Common;

namespace GPBA.Domain.Entities;

/// <summary>
/// Сущность поставщика
/// </summary>
public class Supplier
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Наименование поставщика
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Перечень офееров поставщика с защитой доступа
    /// </summary>
    public IReadOnlyList<Offer> Offers => _offers;
    private readonly List<Offer> _offers = [];

    private Supplier()
    {
    }

    private Supplier(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Метод создания нового поставщика
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Result<Supplier, Error> Create(string name)
    {
        name = name.Trim();
        if (name.IsEmpty() || name.Length > Constraints.SHORT_FIELD_LENGTH)
            return ErrorList.General.ValueIsInvalid();

        return new Supplier(name);
    }

    /// <summary>
    /// Метод добавления оффера поставщика
    /// </summary>
    /// <param name="offer"></param>
    /// <returns></returns>
    public Result<bool, Error> AddOffer(Offer offer)
    {
        _offers.Add(offer);

        return true;
    }
}
