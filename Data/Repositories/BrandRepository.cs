using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories;

public class BrandRepository(
    ApplicationDbContext context)
    : Repository<Brand>(context), IBrandRepository
{
    public async Task<IEnumerable<Brand>> GetAllOrderedAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderBy(brand => brand.Name)
            .ToListAsync();
    }

    public async Task<bool> NameExistsAsync(string name, int? excludedId = null)
    {
        var query = _dbSet.Where(brand => brand.Name == name.Trim());

        if (excludedId.HasValue)
        {
            query = query.Where(brand => brand.Id != excludedId.Value);
        }

        return await query.AnyAsync();
    }
}
