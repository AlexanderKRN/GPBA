namespace GPBA.Application.Features.Offers.GetOffers;

/// <summary>
/// Модель данных в запросе на получение перечня офферов
/// </summary>
/// <param name="SearchItem"></param>
/// <param name="SortItem"></param>
public record GetOffersRequest(
    string? SearchItem,
    string SortItem);