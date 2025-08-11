namespace TestTruckStore.Api.Dtos
{
    public record TruckDto(int Id, string Model, string Brand, int BrandId, int maxSpeed, int maxLiftingCapacity, int Price, DateOnly ReleaseDate);
}
