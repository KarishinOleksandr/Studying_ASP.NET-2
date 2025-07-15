using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Endpoints;

namespace TestTruckStore.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TruckStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();


            await app.MigrateDb();
            app.MapTruckEndpoint();
            app.BrandEndpoint();

            app.Run();
        }
    }
}
