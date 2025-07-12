namespace TestTruckStore.Api.Dtos
{
    public record class CreateTruckDto(string Model, string Brand, decimal Price, DateOnly ReleaseSate);
}
