using ExpressVoiture.Models.ViewModels;

namespace ExpressVoiture.Interfaces
{
    public interface IVehicleListingService
    {
        Task<IEnumerable<VehicleListingItemViewModel>> GetAvailableAsync();
    }
}
