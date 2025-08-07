namespace GPBA.Application.Dtos;

/// <summary>
/// DTO-модель оффера
/// </summary>
/// <param name="Id"></param>
/// <param name="Brand"></param>
/// <param name="Model"></param>
/// <param name="SupplierName"></param>
/// <param name="CreatedAt"></param>
public record OfferDto(
    int Id,
    string Brand,
    string Model,
    string SupplierName,
    DateTime CreatedAt);