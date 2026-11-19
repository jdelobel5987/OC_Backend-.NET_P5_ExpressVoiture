using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using ExpressVoiture.Models.ViewModels;

namespace ExpressVoiture.Services
{
    public class VehicleListingService(
        IVehicleListingRepository repository) : IVehicleListingService
    {
        public async Task<IEnumerable<VehicleListingItemSummaryViewModel>> GetAvailableAsync()
        {
            var summaries = await repository.GetAvailableVehicleSummariesAsync();

            return summaries
                .Select(dto => new VehicleListingItemSummaryViewModel
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

        public async Task<VehicleListingItemDetailsViewModel?> GetDetailsByIdAsync(int id)
        {
            var details = await repository.GetDetailsByIdAsync(id);

            if (details is null) return null;

            return new VehicleListingItemDetailsViewModel
                {
                    ListingId = details.ListingId,
                    AskingPrice = details.AskingPrice,
                    AvailabilityDate = details.AvailabilityDate,
                    Year = details.Year,
                    Version = details.Version,
                    ModelName = details.ModelName,
                    BrandName = details.BrandName,
                    Repairs = [..details.Repairs]
                };
        }

        public async Task<VehicleListingEditViewModel?> GetEditModelAsync(int id)
        {
            var model = await repository.GetDetailsByIdAsync(id);

            if (model is null) return null;

            return new VehicleListingEditViewModel
            {
                ListingId = model.ListingId,
                AskingPrice = model.AskingPrice,
                AvailabilityDate = model.AvailabilityDate,
                Year = model.Year,
                Version = model.Version,
                ModelName = model.ModelName,
                BrandName = model.BrandName,
                Repairs = [..model.Repairs],
                RepairTypeOptions = [..await GetRepairTypeOptionsAsync()]
            };
        }

        public async Task<IEnumerable<string>> GetRepairTypeOptionsAsync()
        {
            return await repository.GetRepairTypeNamesAsync();
        }

        public async Task<bool> UpdateAsync(int id, VehicleListingEditViewModel model) 
        {
            // TODO
            return true; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // TODO
            return true;
        }
    }
}
