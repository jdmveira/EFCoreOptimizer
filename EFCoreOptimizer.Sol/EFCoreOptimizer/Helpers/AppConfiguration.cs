using Microsoft.Extensions.Configuration;
using System.IO;

namespace EFCoreOptimizer.Helpers
{
    public static class AppConfiguration
    {
        public static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
