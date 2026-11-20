using ExpressVoiture.Models.DTOs;
using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces
{
    public interface IVehicleListingRepository : IRepository<VehicleListing>
    {
        Task<IEnumerable<VehicleListingItemSummaryDto>> GetAvailableVehicleSummariesAsync();
        Task<VehicleListingItemDetailsDto?> GetDetailsByIdAsync(int id);
        Task<IEnumerable<string>> GetRepairTypeNamesAsync();
        Task<AdminVehicleListingDto?> GetByVehicleIdAsync(int vehicleId);
    }
}
