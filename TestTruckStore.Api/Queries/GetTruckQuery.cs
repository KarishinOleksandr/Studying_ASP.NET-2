using MediatR;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Queries
{
    public record GetTruckQuery : IRequest<TruckDto[]>
    {
    }
}
