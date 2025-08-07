using GPBA.Application.Dtos;

namespace GPBA.Application.Features.Offers.GetOffers;

/// <summary>
/// Модель ответа на запрос перечня офферов
/// </summary>
/// <param name="Offers"></param>
/// <param name="TotalCount"></param>
public record GetOffersResponse(
    IEnumerable<OfferDto> Offers,
    int TotalCount);