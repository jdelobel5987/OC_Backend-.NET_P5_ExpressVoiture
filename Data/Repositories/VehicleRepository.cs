using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.DTOs.Admin;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories;

public class VehicleRepository(
    ApplicationDbContext context) : Repository<Vehicle>(context), IVehicleRepository
{
    public async Task<IEnumerable<VehicleSelectorOptionDto>> GetSelectorOptionsAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderBy(vehicle => vehicle.Model.Brand.Name)
            .ThenBy(vehicle => vehicle.Model.Name)
            .ThenBy(vehicle => vehicle.Year)
            .Select(vehicle => new VehicleSelectorOptionDto
            {
                Id = vehicle.Id,
                BrandName = vehicle.Model.Brand.Name,
                ModelName = vehicle.Model.Name,
                Year = vehicle.Year
            })
            .ToListAsync();
    }
}
