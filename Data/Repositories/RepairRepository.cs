using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories;

public class RepairRepository(
    ApplicationDbContext context)
    : Repository<Repair>(context), IRepairRepository
{
    public async Task<IEnumerable<AdminRepairDto>> GetByVehicleIdAsync (int vehicleId)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(repair => repair.VehicleId == vehicleId)
            .OrderBy(repair => repair.RepairType.Name)
            .Select(repair => new AdminRepairDto
            {
                Id = repair.Id,
                vehicleId = repair.VehicleId,
                RepairTypeId = repair.RepairTypeId,
                RepairTypeName = repair.RepairType.Name,
                Price = repair.Price
            })
            .ToListAsync();
    }
}
