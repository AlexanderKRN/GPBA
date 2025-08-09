using CSharpFunctionalExtensions;
using GPBA.Application.Dtos;
using GPBA.Domain.Common;

namespace GPBA.Application.Features.Offers.GetOffers;

/// <summary>
/// Обработка запроса по получению перечня офферов
/// </summary>
public class GetOffersHandler
{
    private readonly ISupplierRepository _supplierRepository;

    public GetOffersHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    /// <summary>
    /// Метод обработчика
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<Result<GetOffersResponse, Error>> Handle(
        GetOffersRequest request,
        CancellationToken ct)
    {
        try
        {
            var offers = await _supplierRepository.GetOffers(request.SearchItem, ct);

            Func<OfferDto, object> selectorKey = request.SortItem.ToLower() switch
            {
                "brand" => o => o.Brand,
                "model" => o => o.Model,
                _ => p => p.SupplierName
            };

            return new GetOffersResponse(
                offers.OrderBy(selectorKey),
                offers.Count);
        }
        catch (Exception e)
        {
            return ErrorList.General.Internal(e.Message);
        }
    }
}
