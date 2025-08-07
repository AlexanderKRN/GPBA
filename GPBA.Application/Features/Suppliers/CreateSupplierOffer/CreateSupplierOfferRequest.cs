namespace GPBA.Application.Features.Suppliers.CreateSupplierOffer;

/// <summary>
/// Модель данных в запросе по новому офферу
/// </summary>
/// <param name="SupplierId"></param>
/// <param name="Brand"></param>
/// <param name="Model"></param>
public record CreateSupplierOfferRequest(
    int SupplierId,
    string Brand,
    string Model);