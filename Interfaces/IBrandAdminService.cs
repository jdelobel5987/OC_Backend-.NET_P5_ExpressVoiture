using ExpressVoiture.Models.ViewModels.Admin;

namespace ExpressVoiture.Interfaces;

public interface IBrandAdminService
{
    Task<BrandIndexViewModel> GetIndexModelAsync(int? editId = null);
    Task<bool> CreateAsync(BrandFormViewModel model);
    Task<bool> UpdateAsync(BrandFormViewModel model);
    Task<bool> DeleteAsync(int id);
}
