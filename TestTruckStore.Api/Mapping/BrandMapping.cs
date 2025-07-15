using TestTruckStore.Api.Dtos;
using TestTruckStore.Api.Models;

namespace TestTruckStore.Api.Mapping
{
    public static class BrandMapping
    {
        public static BrandDtocs ToDto (this Brand brand)
        {
            return new BrandDtocs(brand.Id, brand.Name);
        }
    }
}
