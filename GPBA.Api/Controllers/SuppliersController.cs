using GPBA.Api.Common;
using GPBA.Application.Features.Suppliers.CreateSupplier;
using GPBA.Application.Features.Suppliers.CreateSupplierOffer;
using GPBA.Application.Features.Suppliers.GetSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace GPBA.Api.Controllers;

/// <summary>
/// Контроллер обработки поставщиков
/// </summary>
public class SuppliersController : ApplicationController
{
    /// <summary>
    /// Создание нового поставщика
    /// </summary>
    /// <param name="request"></param>
    /// <param name="handler"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateSupplierRequest request,
        [FromServices] CreateSupplierHandler handler,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    /// <summary>
    /// Получение топ-3 популярных поставщиков
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
    [FromServices] GetSuppliersHandler handler,
    CancellationToken ct)
    {
        var result = await handler.Handle(ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    /// <summary>
    /// Создание оффера с привязкой к поставщику по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="handler"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost("offer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateSupplierOfferRequest request,
        [FromServices] CreateSupplierOfferHandler handler,
        CancellationToken ct)
    {
        var result = await handler.Handle(request, ct);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
