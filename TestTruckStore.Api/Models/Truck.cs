namespace TestTruckStore.Api.Models
{
    public class Truck
    {
        public int Id { get; set; }

        public required string Model { get; set; }

        public int maxSpeed { get; set; }

        public int maxLiftingCapacity { get; set; }

        public int Price { get; set; }

        public DateOnly ReleaseSate { get; set; }

        public int BrandId { get; set; }

        public Brand? BrandName { get; set; }

    }
}
