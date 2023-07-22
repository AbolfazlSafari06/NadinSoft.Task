using Microsoft.EntityFrameworkCore;
using NadinSoft.Infrastructure.EFContext;

namespace NadinSoft.API;

public static class DatabaseChecker
{
    public static string _connectionString;
    public static void InitializeConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }
    public static void CheckDatabaseExistOrCreate()
    {
        var options = new DbContextOptionsBuilder<NadinSoftContext>()
            .UseSqlServer(_connectionString)
            .Options;

        using (var context = new NadinSoftContext(options))
        {
            bool canConnect = context.Database.CanConnect();
            if (!canConnect)
            {
                context.Database.Migrate();
            }
        }
    }
}