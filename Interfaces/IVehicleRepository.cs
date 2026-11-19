using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IEnumerable<VehicleSelectorOptionDto>> GetSelectorOptionsAsync();

    Task<AdminVehicleDetailsDto?> GetAdminDetailsByIdAsync(int id);
}
