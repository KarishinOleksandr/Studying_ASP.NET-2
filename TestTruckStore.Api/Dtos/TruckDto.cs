namespace TestTruckStore.Api.Dtos
{
    public record class TruckDto(int Id, string Model, string Brand, decimal Price, DateOnly ReleaseSate);
}
