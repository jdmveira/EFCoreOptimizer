using EFCoreOptimizer.Persistence.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOptimizer.Persistence.EFCHelpers
{
    public class SqliteInMemory
    {
        public DataContext GetContextWithSetup()
        {
            var context = new DataContext(CreateOptions<DataContext>());
            context.Database.EnsureCreated();

            return context;
        }

        public static DbContextOptions<T> CreateOptions<T>() where T : DbContext
        {
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };

            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            var builder = new DbContextOptionsBuilder<T>();
            builder
                .UseSqlite(connection)
                .EnableSensitiveDataLogging();

            return builder.Options;
        }
    }
}
