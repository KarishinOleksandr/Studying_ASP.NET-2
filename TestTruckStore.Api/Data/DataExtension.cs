using Microsoft.EntityFrameworkCore;

namespace TestTruckStore.Api.Data
{
    public static class DataExtension
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TruckStoreContext>();
            dbContext.Database.Migrate();
        }
    }
}
