namespace TestTruckStore.Api.Dtos
{
    public record class UpdateTruckDto(string Model, string Brand, decimal Price, DateOnly ReleaseSate);
}
