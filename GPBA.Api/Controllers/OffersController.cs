using GPBA.Api.Common;
using GPBA.Application.Features.Offers.GetOffers;
using Microsoft.AspNetCore.Mvc;

namespace GPBA.Api.Controllers;

/// <summary>
/// Контроллер обработки офферов
/// </summary>
public class OffersController : ApplicationController
{
    /// <summary>
    /// Получение списка офферов поиском по бренду /модели /наименованию поставщика,
    /// с сортировкой результата по ключу brand /model /иное
    /// </summary>
    /// <param name="request"></param>
    /// <param name="handler"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromQuery] GetOffersRequest request,
        [FromServices] GetOffersHandler handler,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}