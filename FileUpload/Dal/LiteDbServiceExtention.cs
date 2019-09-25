using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Dal
{
    public static class LiteDbServiceExtention
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            services.Configure<LiteDbConfig>(options => options.DatabasePath = databasePath);
        }
    }
}
