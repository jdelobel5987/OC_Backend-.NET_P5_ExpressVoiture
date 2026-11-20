using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories;

public class PurchaseRepository(
    ApplicationDbContext context)
    : Repository<Purchase>(context), IPurchaseRepository
{
    public async Task<AdminPurchaseDto?> GetByVehicleIdAsync(int vehicleId)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(purchase => purchase.VehicleId == vehicleId)
            .Select(purchase => new AdminPurchaseDto
            {
                Id = purchase.Id,
                VehicleId = purchase.VehicleId,
                Price = purchase.Price,
                Date = purchase.Date
            })
            .FirstOrDefaultAsync();
    }
}
