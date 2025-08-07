using GPBA.Application.Features;
using GPBA.Infrastructure.DbContexts;

namespace GPBA.Infrastructure.Providers;

/// <summary>
/// Провайдер UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод сохранения изменений
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _dbContext.SaveChangesAsync(ct);
    }
}
