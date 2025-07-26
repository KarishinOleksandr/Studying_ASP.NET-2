using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Mapping;
using TestTruckStore.Api.Models;
using MediatR;
using TestTruckStore.Api.Queries;
using TestTruckStore.Api.Command;


namespace TestTruckStore.Api.Endpoints
{
    public static class TruckEndpoint
    {
        const string GetTruckEndpoint = "GetTruck";

        public static RouteGroupBuilder MapTruckEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("trucks").WithParameterValidation();

            // GET / READ
            group.MapGet("/", async (IMediator mediator) => 
                await mediator.Send(new GetTruckQuery(), new CancellationToken()));
            group.MapGet("/{id}", async (int id, IMediator mediator) =>
            {
                TruckDto? truckDto = await mediator.Send(new GetTruckByidQuery(id), new CancellationToken());
                if (truckDto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(truckDto);
            }).WithName(GetTruckEndpoint);

            // POST / CREATE
            group.MapPost("/", async (CreateTruckCommand command, IMediator mediator) =>
            {
                Truck truck = await mediator.Send(command);

                return Results.CreatedAtRoute(GetTruckEndpoint, new { id = truck.Id }, truck.ToDto());
            });

            // PUT / UPDATE
            group.MapPut("/{id}", async (int id, UpdateTruckCommand command, IMediator mediator) =>
            {
                var updatedCommand = command with { Id = id };

                Truck truck = await mediator.Send(updatedCommand);

                return Results.Ok(truck);
            });

            group.MapDelete("/{id}", async (int id, TruckStoreContext dbContext) =>
            {
                var exist = dbContext.Trucks.Find(id);
                if ( exist is null)
                {
                    return Results.NotFound();
                }
                dbContext.Remove(exist);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
