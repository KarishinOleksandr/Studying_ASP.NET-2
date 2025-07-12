using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Endpoints;

namespace TestTruckStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapTruckEndpoint();

            app.Run();
        }
    }
}
