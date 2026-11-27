using ExpressVoiture.Models.ViewModels.Admin;

namespace ExpressVoiture.Interfaces;

public interface IModelAdminService
{
    Task<ModelIndexViewModel> GetIndexModelAsync(int? editId = null);

    Task<bool> CreateAsync(ModelFormViewModel model);

    Task<bool> UpdateAsync(ModelFormViewModel model);

    Task<bool> DeleteAsync(int id);

}
