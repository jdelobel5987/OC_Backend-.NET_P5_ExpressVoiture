using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces;

public interface IRepairRepository : IRepository<Repair>
{
    Task<IEnumerable<AdminRepairDto>> GetByVehicleIdAsync(int vehicleId);
}
