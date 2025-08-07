using CSharpFunctionalExtensions;
using GPBA.Domain.Common;

namespace GPBA.Application.Features.Suppliers.GetSuppliers;

/// <summary>
/// Обработка запроса по получению перечня поставщиков
/// </summary>
public class GetSuppliersHandler
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSuppliersHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    /// <summary>
    /// Метод обработчика
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<Result<GetSuppliersResponse, Error>> Handle(CancellationToken ct)
    {
        try
        {
            var suppliers = await _supplierRepository.GetMostPopular(ct);

            return new GetSuppliersResponse(suppliers);
        }
        catch (Exception e)
        {
            return ErrorList.General.Internal(e.Message);
        }
    }
}
