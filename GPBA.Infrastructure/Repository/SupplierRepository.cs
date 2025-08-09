using CSharpFunctionalExtensions;
using Dapper;
using GPBA.Application.Dtos;
using GPBA.Application.Features;
using GPBA.Domain.Common;
using GPBA.Domain.Entities;
using GPBA.Infrastructure.Dapper;
using GPBA.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GPBA.Infrastructure.Repository;

/// <summary>
/// Репозиторий работы с поставщиками
/// </summary>
public class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DapperContext _dapperContext;

    public SupplierRepository(
        ApplicationDbContext dbContext,
        DapperContext dapperContext)
    {
        _dbContext = dbContext;
        _dapperContext = dapperContext;
    }

    /// <summary>
    /// Метод получения топ-3 популярных поставщиков
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<SupplierDto>> GetMostPopular(CancellationToken ct)
    {
        var query = """
                    SELECT
                        TOP 3 s.name AS Name,
                        COUNT(*) AS OffersQuantity 
                    FROM suppliers s 
                        JOIN offers o 
                            ON s.id = o.supplier_id 
                    GROUP BY
                        s.name ORDER BY 2 DESC
                    """;

        using var db = _dapperContext.CreateConnection();
        var popularSuppliers = await db.QueryAsync<SupplierDto>(query);

        return popularSuppliers.ToList();
    }

    /// <summary>
    /// Метод получения всех офферов
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<OfferDto>> GetOffers(
        string? searchItem,
        CancellationToken ct)
    {
        return await _dbContext.Offers
            .Join(
                _dbContext.Suppliers,
                o => o.SupplierId,
                s => s.Id,
                (o, s) => new
                {
                    o.Id,
                    o.Brand,
                    o.Model,
                    SupplierName = s.Name,
                    o.CreatedAt
                })
            .Where(x => string.IsNullOrWhiteSpace(searchItem)
                    || x.Brand.ToUpper().Contains(searchItem)
                    || x.Model.ToUpper().Contains(searchItem)
                    || x.SupplierName.ToUpper().Contains(searchItem))
            .Select(x => new OfferDto(x.Id, x.Brand, x.Model, x.SupplierName, x.CreatedAt))
            .AsNoTracking()
            .ToListAsync(ct);
    }

    /// <summary>
    /// Метод добавления поставщика
    /// </summary>
    /// <param name="supplier"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task Add(Supplier supplier, CancellationToken ct)
    {
        await _dbContext.Suppliers.AddAsync(supplier, ct);
    }

    /// <summary>
    /// Метод получения поставщика по ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<Result<Supplier, Error>> GetById(int id, CancellationToken ct)
    {
        var supplier = await _dbContext.Suppliers
            .FirstOrDefaultAsync(s => s.Id == id, ct);
        if (supplier is null)
            return ErrorList.General.NotFound(id);

        return supplier;
    }
}
