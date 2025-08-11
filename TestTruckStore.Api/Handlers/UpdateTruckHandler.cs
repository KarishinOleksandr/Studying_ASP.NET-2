using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Command;
using TestTruckStore.Api.Data;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Mapping;
using TestTruckStore.Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestTruckStore.Api.Handlers
{
    public class UpdateTruckHandler : IRequestHandler<UpdateTruckCommand, Truck>
    {
        private readonly TruckStoreContext _context;
        private IMediator mediator;

        public UpdateTruckHandler(TruckStoreContext context)
        {
            _context = context;
        }

        public async Task<Truck> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Trucks.FindAsync(request.Id);

            if (exist == null) 
            {
                Truck truck = new Truck
                {
                    Model = request.Model,
                    BrandId = request.BrandId,
                    maxSpeed = request.maxSpeed,
                    maxLiftingCapacity = request.maxLiftingCapacity,
                    Price = request.Price,
                    ReleaseDate = request.ReleaseDate,
                };
                truck.BrandName = await _context.Brands.FindAsync(request.BrandId);
                await _context.AddAsync(truck);
                await _context.SaveChangesAsync();

                return truck;
            }

            _context.Entry(exist).CurrentValues.SetValues(request);
            exist.BrandName = await _context.Brands.FindAsync(request.BrandId);
            await _context.SaveChangesAsync();

            return exist;
        }
    }
}
