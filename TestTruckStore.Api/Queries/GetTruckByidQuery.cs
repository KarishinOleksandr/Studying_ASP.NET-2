using MediatR;
using TestTruckStore.Api.Dtos;

namespace TestTruckStore.Api.Queries
{
    public class GetTruckByidQuery(int id) : IRequest<TruckDto?>
    {
        public int ID { get; set; } = id;
    }
}
