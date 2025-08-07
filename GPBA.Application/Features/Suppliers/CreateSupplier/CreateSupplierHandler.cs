using CSharpFunctionalExtensions;
using GPBA.Domain.Common;
using GPBA.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GPBA.Application.Features.Suppliers.CreateSupplier;

/// <summary>
/// Обработка запроса по созданию нового поставщика
/// </summary>
public class CreateSupplierHandler
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateSupplierHandler> _logger;

    public CreateSupplierHandler(
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
        CreateSupplierRequest request,
        CancellationToken ct)
    {
        var supplier = Supplier.Create(request.Name);
        if (supplier.IsFailure)
            return supplier.Error;

        await _supplierRepository.Add(supplier.Value, ct);

        await _unitOfWork.SaveChangesAsync(ct);

        _logger.LogInformation(
            "Новый поставщик создан, ID: {id}", supplier.Value.Id);

        return supplier.Value.Id;
    }
}