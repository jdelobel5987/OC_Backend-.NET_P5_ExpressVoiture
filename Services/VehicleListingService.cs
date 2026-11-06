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
            var summaries = await repository.GetAvailableVehicleSummariesAsync();

            return summaries
                .Select(dto => new VehicleListingItemViewModel
                {
                    ListingId = dto.ListingId,
                    AskingPrice = dto.AskingPrice,
                    AvailabilityDate = dto.AvailabilityDate,
                    Year = dto.Year,
                    Version = dto.Version,
                    ModelName = dto.ModelName,
                    BrandName = dto.BrandName
                })
                .ToList();
        }
    }
}
