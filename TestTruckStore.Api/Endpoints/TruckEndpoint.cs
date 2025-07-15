using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Mapping;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Endpoints
{
    public static class TruckEndpoint
    {
        const string GetTruckEndpoint = "GetTruck";

        public static RouteGroupBuilder MapTruckEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("trucks").WithParameterValidation();

            // GET / READ
            group.MapGet("/", async (TruckStoreContext dbContext) => 
                await dbContext.Trucks.Include(truck => truck.BrandName).Select(truck => truck.ToDto()).AsNoTracking().ToListAsync());
            group.MapGet("/{id}", async (int id, TruckStoreContext dbContext) =>
            {
                Truck? truck = await dbContext.Trucks.FindAsync(id);
                if (truck == null)
                {
                    return Results.NotFound();
                }
                truck.BrandName = await dbContext.Brands.FindAsync(truck.BrandId);

                return Results.Ok(truck.ToDto());
            }).WithName(GetTruckEndpoint);

            // POST / CREATE
            group.MapPost("/", async (CreateTruckDto addTruck, TruckStoreContext dbContext) =>
            {

                Truck truck = addTruck.ToEntity();  
                truck.BrandName = dbContext.Brands.Find(addTruck.BrandId);

                dbContext.Trucks.Add(truck);

                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetTruckEndpoint, new { id = truck.Id }, truck.ToDto());
            });

            // PUT / UPDATE
            group.MapPut("/{id}", async (int id, UpdateTruckDto updateTruck, TruckStoreContext dbContext) =>
            {
                var exist = await dbContext.Trucks.FindAsync(id);

                if (exist is null)
                {
                    Truck truck =  updateTruck.ToEntity(id);
                    truck.BrandName = dbContext.Brands.Find(updateTruck.BrandId);

                    dbContext.Trucks.Add(truck);

                    await dbContext.SaveChangesAsync();

                    return Results.CreatedAtRoute(GetTruckEndpoint, new { id = truck.Id }, truck.ToDto());
                }

                dbContext.Entry(exist).CurrentValues.SetValues(updateTruck.ToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (int id, TruckStoreContext dbContext) =>
            {
                var exist = dbContext.Trucks.Find(id);
                dbContext.Remove(exist);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
