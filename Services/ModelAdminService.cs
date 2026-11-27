using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using ExpressVoiture.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Services;

public class ModelAdminService(
    IModelRepository modelRepository,
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork
) : IModelAdminService
{
    public async Task<ModelIndexViewModel> GetIndexModelAsync(int? editId = null)
    {
        var models = await modelRepository.GetAllOrderedAsync();

        var brands = await brandRepository.GetAllOrderedAsync();

        var brandOptions = brands
            .Select(brand => new BrandOptionViewModel
            {
                Id = brand.Id,
                Name = brand.Name
            })
            .ToList();

        var page = new ModelIndexViewModel
        {
            Models =
            [
                .. models.Select(model => new ModelListItemViewModel{
                    Id = model.Id,
                    Name = model.Name,
                    BrandId = model.BrandId,
                    BrandName = model.Brand.Name
                })
            ],

            CreateModel = new ModelFormViewModel
            {
                BrandOptions = [.. brandOptions]
            }
        };

        if (editId.HasValue)
        {
            var model = await modelRepository.GetByIdAsync(editId.Value);

            if (model is not null)
            {
                page.EditModel = new ModelFormViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    BrandId = model.BrandId,
                    BrandOptions = [.. brandOptions]
                };
            }
        }

        return page;
    }

    public async Task<bool> CreateAsync(ModelFormViewModel model)
    {
        var brand = await brandRepository.GetByIdAsync(model.BrandId);

        if (brand is null)
            return false;

        var name = model.Name.Trim();

        var nameExists = await modelRepository.NameExistsForBrandAsync(name, model.BrandId);

        if (nameExists)
            return false;

        await modelRepository.AddAsync(new Model
        {
            Name = name,
            BrandId = model.BrandId
        });

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(ModelFormViewModel model)
    {
        if (!model.Id.HasValue)
            return false;

        var existingModel = await modelRepository.GetByIdAsync(model.Id.Value);

        if (existingModel is null)
            return false;

        var brand = await brandRepository.GetByIdAsync(model.BrandId);

        if (brand is null)
            return false;

        var name = model.Name.Trim();

        var nameExists = await modelRepository.NameExistsForBrandAsync(name, model.BrandId, existingModel.Id);

        if (nameExists)
            return false;

        existingModel.Name = name;
        existingModel.BrandId = model.BrandId;

        modelRepository.Update(existingModel);
        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var model = await modelRepository.GetByIdAsync(id);

        if (model is null)
            return false;

        modelRepository.Delete(model);

        try
        {
            await unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }
}
