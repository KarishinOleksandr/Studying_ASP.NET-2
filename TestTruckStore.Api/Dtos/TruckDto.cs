namespace TestTruckStore.Api.Dtos
{
    public record class TruckDto(int Id, string Model, string Brand, int maxSpeed, int maxLiftingCapacity, int Price, DateOnly ReleaseSate);
}
