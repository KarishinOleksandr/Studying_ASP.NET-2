using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Mapping;

namespace TestTruckStore.Api.Endpoints
{
    public static class BrandEndpoints
    {
        public static RouteGroupBuilder BrandEndpoint (this WebApplication app)
        {
            var group = app.MapGroup("brands");

            group.MapGet("/", async (TruckStoreContext dbContext) => await dbContext.Brands.Select(brand => brand.ToDto()).AsNoTracking().ToListAsync());

            return group;
        }
    }
}
