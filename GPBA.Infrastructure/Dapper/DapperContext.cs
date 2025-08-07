using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GPBA.Infrastructure.Dapper;

/// <summary>
/// Контекст работы с Dapper
/// </summary>
public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Метод создания SQL-соединения
    /// </summary>
    /// <returns></returns>
    public IDbConnection CreateConnection() =>
        new SqlConnection(_configuration.GetConnectionString("GPBADatabase"));
}
