using System.ComponentModel.DataAnnotations;

namespace TestTruckStore.Api.Dtos
{
    public record UpdateTruckDto(
        [Required][StringLength(50)] string Model,
        [Required]int BrandId,
        [Required][Range(60, 180)] int maxSpeed,
        [Required][Range(10, 60)] int maxLiftingCapacity,
        [Required][Range(1, 9999999999)] int Price,
        [Required]DateOnly ReleaseDate);
}
