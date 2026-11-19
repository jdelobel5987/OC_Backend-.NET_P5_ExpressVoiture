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

        public async Task<VehicleListingItemDetailsDto?> GetDetailsByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(vl => vl.Id == id)
                .Select(vl => new VehicleListingItemDetailsDto
                {
                    ListingId = vl.Id,
                    AskingPrice = vl.AskingPrice,
                    AvailabilityDate = vl.AvailabilityDate,
                    Year = vl.Vehicle.Year,
                    Version = vl.Vehicle.Version,
                    ModelName = vl.Vehicle.Model.Name,
                    BrandName = vl.Vehicle.Model.Brand.Name,
                    Repairs = vl.Vehicle.Repairs
                        .Select(r => r.RepairType.Name)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetRepairTypeNamesAsync()
        {
            return await _context.RepairTypes
                .AsNoTracking()
                .OrderBy(repairType => repairType.Name)
                .Select(repairType => repairType.Name)
                .ToListAsync();
        }
    }
}
