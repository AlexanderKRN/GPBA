using CSharpFunctionalExtensions;
using GPBA.Application.Features.Suppliers.CreateSupplier;
using GPBA.Domain.Common;
using GPBA.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GPBA.Application.Features.Suppliers.CreateSupplierOffer;

/// <summary>
/// Обработка запроса по созданию нового оффера поставщика
/// </summary>
public class CreateSupplierOfferHandler
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateSupplierHandler> _logger;

    public CreateSupplierOfferHandler(
        ISupplierRepository supplierRepository,
        IUnitOfWork unitOfWork,
        ILogger<CreateSupplierHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Метод обработчика
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<Result<int, Error>> Handle(
        CreateSupplierOfferRequest request,
        CancellationToken ct)
    {
        var supplier = await _supplierRepository.GetById(request.SupplierId, ct);
        if (supplier.IsFailure)
            return supplier.Error;

        var offer = Offer.Create(request.Brand, request.Model);
        if (offer.IsFailure)
            return offer.Error;

        supplier.Value.AddOffer(offer.Value);

        await _unitOfWork.SaveChangesAsync(ct);

        _logger.LogInformation(
            "Новый оффер создан, ID: {Id}", offer.Value.Id);

        return offer.Value.Id;
    }
}
