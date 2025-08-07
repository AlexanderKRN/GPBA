using GPBA.Application.Dtos;

namespace GPBA.Application.Features.Suppliers.GetSuppliers;

/// <summary>
/// Модель ответа на запрос перечня поставщиков
/// </summary>
/// <param name="Suppliers"></param>
public record GetSuppliersResponse(IEnumerable<SupplierDto> Suppliers);