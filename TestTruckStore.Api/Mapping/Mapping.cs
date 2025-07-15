using Microsoft.EntityFrameworkCore;
using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Mapping
{
    public static class Mapping
    {
        public static Truck ToEntity(this CreateTruckDto truck)
        {
            return new Truck()
            {
                Model = truck.Model,
                BrandId = truck.BrandId,
                maxSpeed = truck.maxSpeed,
                maxLiftingCapacity = truck.maxLiftingCapacity,
                Price = truck.Price,
                ReleaseSate = truck.ReleaseSate

            };
        }
        public static Truck ToEntity(this UpdateTruckDto truck, int id)
        {
            return new Truck()
            {
                Id= id,
                Model = truck.Model,
                BrandId = truck.BrandId,
                maxSpeed = truck.maxSpeed,
                maxLiftingCapacity = truck.maxLiftingCapacity,
                Price = truck.Price,
                ReleaseSate = truck.ReleaseSate

            };
        }


        public static TruckDto ToDto(this Truck truck) 
        {
            return new(
                truck.Id,
                truck.Model,
                truck.BrandName!.Name,
                truck.BrandId,
                truck.maxSpeed,
                truck.maxLiftingCapacity,
                truck.Price,
                truck.ReleaseSate
            );
        }
    }
}