using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces;

public interface IModelRepository : IRepository<Model>
{
    Task<IEnumerable<Model>> GetAllOrderedAsync();

    Task<bool> NameExistsForBrandAsync(
        string Name,
        int brandId,
        int? excludeId = null
    );
}
