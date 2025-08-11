using MediatR;
using System.ComponentModel.DataAnnotations;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Command
{
    public record CreateTruckCommand(
        [Required][StringLength(50)] string Model,
        [Required] int BrandId,
        [Required][Range(60, 180)] int maxSpeed,
        [Required][Range(10, 60)] int maxLiftingCapacity,
        [Required][Range(1, 9999999999)] int Price,
        [Required] DateOnly ReleaseDate) : IRequest<Truck>;
}
