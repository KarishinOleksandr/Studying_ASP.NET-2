using TestTruckStore.Api.Dtos;

namespace TestTruckStore.Api.Endpoints
{
    public static class TruckEndpoint
    {
        const string GetTruckEndpoint = "GetTruck";

        private static readonly List<TruckDto> trucks = [
                new(
                    1,
                    "Model123",
                    "Marcedes",
                    55000M,
                    new DateOnly(2004, 8, 5)),
                new (
                    2,
                    "Model124",
                    "Marcedes",
                    56000M  ,
                    new DateOnly(2004, 8, 5))
        ];

        public static RouteGroupBuilder MapTruckEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("trucks");

            // GET / READ
            group.MapGet("/", () => trucks);
            group.MapGet("/{id}", (int id) =>
            {
                TruckDto? truck = trucks.Find(truck => truck.Id == id);

                return truck is null ? Results.NotFound() : Results.Ok(truck);
            }).WithName(GetTruckEndpoint);

            // POST / CREATE
            group.MapPost("/", (CreateTruckDto addTruck) =>
            {
                TruckDto newTruck = new(trucks.Count + 1, addTruck.Model, addTruck.Brand, addTruck.Price, addTruck.ReleaseSate);

                trucks.Add(newTruck);

                return Results.CreatedAtRoute(GetTruckEndpoint, new { id = newTruck.Id }, newTruck);
            });

            // PUT / UPDATE
            group.MapPut("/{id}", (int id, UpdateTruckDto updateTruck) =>
            { 
                var index = trucks.FindIndex(truck => truck.Id == id);

                if (index == -1)
                {
                    TruckDto newTruck = new(trucks.Count + 1, updateTruck.Model, updateTruck.Brand, updateTruck.Price, updateTruck.ReleaseSate);
                    trucks.Add(newTruck);

                    return Results.CreatedAtRoute(GetTruckEndpoint, new { id = newTruck.Id }, newTruck);
                }

                trucks[index] = new TruckDto(id, updateTruck.Model, updateTruck.Brand, updateTruck.Price, updateTruck.ReleaseSate);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id) =>
            {
                trucks.RemoveAll(trucks => trucks.Id == id);

                return Results.NoContent();
            });

            return group;
        }
    }
}
