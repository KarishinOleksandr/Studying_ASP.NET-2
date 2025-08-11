using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Models;
using TestTruckStore.Api.Queries;

namespace TestTruckStore.Api.Handlers
{
    public class GetTruckHandler : IRequestHandler<GetTruckQuery, TruckDto[]>
    {
        private readonly TruckStoreContext _context;

        public GetTruckHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<TruckDto[]> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            Task.Delay(500).Wait();
            var trucks = await _context.Trucks.Include(t => t.BrandName).ToListAsync(cancellationToken);

            var truckDtos =  new List<TruckDto>();

            foreach (var el in trucks)
            {
                truckDtos.Add(new TruckDto
                (
                    el.Id,
                    el.Model,
                    el.BrandName!.Name.ToString(),
                    el.BrandId,
                    el.maxSpeed,
                    el.maxLiftingCapacity,
                    el.Price,
                    el.ReleaseDate
                ));
            }

            return truckDtos.ToArray();
        }
    }
}
