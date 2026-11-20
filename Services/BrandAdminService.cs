using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using ExpressVoiture.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Services;

public class BrandAdminService(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork)
    : IBrandAdminService
{
    public async Task<BrandIndexViewModel> GetIndexModelAsync(int? editId = null)
    {
        var brands = await brandRepository.GetAllOrderedAsync();

        var model = new BrandIndexViewModel
        {
            Brands = [.. brands.Select(brand => new BrandListItemViewModel{
                Id = brand.Id,
                Name = brand.Name
            })]
        };

        if (editId.HasValue)
        {
            var brand = await brandRepository.GetByIdAsync(editId.Value);

            if (brand is not null)
            {
                model.EditModel = new BrandFormViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
            }
        }

        return model;
    }

    public async Task<bool> CreateAsync(BrandFormViewModel model)
    {
        var name = model.Name.Trim();

        if (await brandRepository.NameExistsAsync(name)) return false;

        await brandRepository.AddAsync(new Brand
        {
            Name = name
        });

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(BrandFormViewModel model)
    {
        if (!model.Id.HasValue) return false;

        var brand = await brandRepository.GetByIdAsync(model.Id.Value);

        if (brand is null) return false;

        var name = model.Name.Trim();

        if (await brandRepository.NameExistsAsync(name, brand.Id)) return false;

        brand.Name = name;

        brandRepository.Update(brand);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var brand = await brandRepository.GetByIdAsync(id);

        if (brand is null) return false;

        brandRepository.Delete(brand);

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
