using System.ComponentModel.DataAnnotations;

namespace TestTruckStore.Api.Dtos
{
    public record CreateTruckDto( 
        [Required][StringLength(50)] string Model, 
        [Required] int BrandId, 
        [Required][Range(60, 180)] int maxSpeed,
        [Required][Range(10, 60)] int maxLiftingCapacity,
        [Required][Range(10000, 9999999999)] int Price,
        [Required]DateOnly ReleaseDate);
}
