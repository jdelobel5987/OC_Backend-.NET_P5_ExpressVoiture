using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using ExpressVoiture.Models.ViewModels;

namespace ExpressVoiture.Services
{
    public class VehicleListingService(
        IVehicleListingRepository repository) : IVehicleListingService
    {
        public async Task<IEnumerable<VehicleListingItemViewModel>> GetAvailableAsync()
        {
            var listings = await repository.GetAvailableWithDetailsAsync();

            return listings
                .Select(l => new VehicleListingItemViewModel
                {
                    ListingId = l.Id,
                    AskingPrice = l.AskingPrice,
                    AvailabilityDate = l.AvailabilityDate,
                    Year = l.Vehicle.Year,
                    Version = l.Vehicle.Version,
                    ModelName = l.Vehicle.Model.Name,
                    BrandName = l.Vehicle.Model.Brand.Name
                })
                .ToList();
        }
    }
}
