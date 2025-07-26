using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Command;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Handlers
{
    public class CreateTruckHandler : IRequestHandler<CreateTruckCommand, Truck>
    {
        private readonly TruckStoreContext _context;

        public CreateTruckHandler (TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<Truck> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truck = new Truck
            {
                Model = request.Model,
                BrandId = request.BrandId,
                maxSpeed = request.maxSpeed,
                maxLiftingCapacity = request.maxLiftingCapacity,
                Price = request.Price,
                ReleaseSate = request.ReleaseSate,  
            };
            truck.BrandName = await _context.Brands.FindAsync(request.BrandId);
            await _context.AddAsync(truck);
            await _context.SaveChangesAsync();

            return truck;
        }
    }
}
