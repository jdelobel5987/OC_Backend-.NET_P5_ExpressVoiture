using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.DTOs;
using ExpressVoiture.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ExpressVoiture.Data.Repositories
{
    public class VehicleListingRepository(
        ApplicationDbContext context)
        : Repository<VehicleListing>(context), IVehicleListingRepository
    {
        public async Task<IEnumerable<VehicleListingItemSummaryDto>> GetAvailableVehicleSummariesAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(vl => vl.SaleDate == null)
                .Select(vl => new VehicleListingItemSummaryDto
                {
                    ListingId = vl.Id,
                    AskingPrice = vl.AskingPrice,
                    AvailabilityDate = vl.AvailabilityDate,
                    Year = vl.Vehicle.Year,
                    Version = vl.Vehicle.Version,
                    ModelName = vl.Vehicle.Model.Name,
                    BrandName = vl.Vehicle.Model.Brand.Name
                })
                .ToListAsync();
        }
    }
}
