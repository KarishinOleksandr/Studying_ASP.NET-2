using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestTruckStore.Api.Data
{
    public static class DataExtension
    {
        public static async Task MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TruckStoreContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
