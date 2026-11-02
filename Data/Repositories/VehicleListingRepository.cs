using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories
{
    public class VehicleListingRepository(
        ApplicationDbContext context)
        : Repository<VehicleListing>(context), IVehicleListingRepository
    {
        public async Task<IEnumerable<VehicleListing>> GetAvailableWithDetailsAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(vl => vl.Vehicle)
                    .ThenInclude(v => v.Model)
                        .ThenInclude(m => m.Brand)
                .Where(vl => vl.SaleDate == null)
                .ToListAsync();
        }
    }
}
