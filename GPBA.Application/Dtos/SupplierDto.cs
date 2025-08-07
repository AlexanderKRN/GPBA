namespace GPBA.Application.Dtos;

/// <summary>
/// DTO-модель поставщика
/// </summary>
/// <param name="Name"></param>
/// <param name="OffersQuantity"></param>
public record SupplierDto(
    string Name,
    int OffersQuantity);