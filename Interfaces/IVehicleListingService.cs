using ExpressVoiture.Models.ViewModels;

namespace ExpressVoiture.Interfaces
{
    public interface IVehicleListingService
    {
        Task<IEnumerable<VehicleListingItemSummaryViewModel>> GetAvailableAsync();  
        Task<VehicleListingItemDetailsViewModel?> GetDetailsByIdAsync(int id);
        Task<VehicleListingEditViewModel?> GetEditModelAsync(int id);
        Task<IEnumerable<string>> GetRepairTypeOptionsAsync();
        Task<bool> UpdateAsync(int id, VehicleListingEditViewModel model);
        Task<bool> DeleteAsync(int id);
    }
}
