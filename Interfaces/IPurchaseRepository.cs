using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
    Task<AdminPurchaseDto?> GetByVehicleIdAsync(int vehicleId);
}
