namespace GPBA.Application.Features;

public interface IUnitOfWork
{
    /// <summary>
    /// Метод сохранения изменений
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken ct);
}