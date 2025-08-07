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
            var suppliers = await _supplierRepository.GetAll(ct);
            var offers = await _supplierRepository.GetOffers(ct);

            List<OfferDto> offerDtos = [];

            foreach (var offer in offers)
            {
                var supplierName = suppliers.FirstOrDefault(
                    s => s.Id == offer.SupplierId)?.Name ?? string.Empty;

                var dto = new OfferDto(
                    offer.Id,
                    offer.Brand,
                    offer.Model,
                    supplierName,
                    offer.CreatedAt);

                offerDtos.Add(dto);
            }

            Func<OfferDto, object> selectorKey = request.SortItem
                .ToLower() switch
                    {
                        "brand" => o => o.Brand,
                        "model" => o => o.Model,
                        _ => p => p.SupplierName
                    };

            var dtosSearch = offerDtos
                    .Where(n => string.IsNullOrWhiteSpace(request.SearchItem)
                        || n.Brand.Contains(request.SearchItem, StringComparison.CurrentCultureIgnoreCase)
                        || n.Model.Contains(request.SearchItem, StringComparison.CurrentCultureIgnoreCase)
                        || n.SupplierName.Contains(request.SearchItem, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(selectorKey);

            return new GetOffersResponse(dtosSearch, offers.Count);
        }
        catch (Exception e)
        {
            return ErrorList.General.Internal(e.Message);
        }
    }
}
