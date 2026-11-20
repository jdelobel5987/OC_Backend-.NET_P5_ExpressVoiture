using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces;

public interface IBrandRepository : IRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAllOrderedAsync();
    Task<bool> NameExistsAsync(string Name, int? excludedId = null);
}
