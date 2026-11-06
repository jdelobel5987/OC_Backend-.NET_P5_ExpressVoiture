using ExpressVoiture.Models.DTOs;
using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces
{
    public interface IVehicleListingRepository : IRepository<VehicleListing>
    {
        Task<IEnumerable<VehicleListingItemSummaryDto>> GetAvailableVehicleSummariesAsync();
    }
}
