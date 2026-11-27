using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data.Repositories;

public class ModelRepository(
    ApplicationDbContext context) : Repository<Model>(context), IModelRepository
{
    public async Task<IEnumerable<Model>> GetAllOrderedAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Include(model => model.Brand)
            .OrderBy(model => model.Brand.Name)
            .ThenBy(model => model.Name)
            .ToListAsync();
    }

    public async Task<bool> NameExistsForBrandAsync(
        string name,
        int brandId,
        int? excludedId = null
    )
    {
        var query = _dbSet.Where(model => 
            model.BrandId == brandId &&
            model.Name == name.Trim());

        if (excludedId.HasValue)
        {
            query = query.Where(model =>
                model.Id != excludedId.Value);
        }

        return await query.AnyAsync();
    }
}
