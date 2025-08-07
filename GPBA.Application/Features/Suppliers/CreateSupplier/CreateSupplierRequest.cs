namespace GPBA.Application.Features.Suppliers.CreateSupplier;

/// <summary>
/// Модель данных в запросе по новому поставщику
/// </summary>
/// <param name="Name"></param>
public record CreateSupplierRequest(
    string Name);