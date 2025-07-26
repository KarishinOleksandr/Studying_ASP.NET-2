using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Queries;

namespace TestTruckStore.Api.Handlers
{
    public class GetTruckByidHandler : IRequestHandler<GetTruckByidQuery, TruckDto>
    {
        private readonly TruckStoreContext _context;

        public GetTruckByidHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<TruckDto> Handle(GetTruckByidQuery request, CancellationToken cancellationToken) 
        {
            var truck = await _context.Trucks
                .Where(t => t.Id == request.ID)
                .Select(t => new TruckDto
                (
                    t.Id,
                    t.Model,
                    t.BrandName!.Name.ToString(),
                    t.BrandId,
                    t.maxSpeed,
                    t.maxLiftingCapacity,
                    t.Price,
                    t.ReleaseSate
                ))
                .FirstOrDefaultAsync(cancellationToken);

            return truck;
        }
    }
}
