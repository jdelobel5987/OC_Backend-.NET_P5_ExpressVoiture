using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ModelsController(
        IModelAdminService modelAdminService
    ) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? editId)
        {
            var model = await modelAdminService.GetIndexModelAsync(editId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var page = await modelAdminService.GetIndexModelAsync();

                model.BrandOptions = page.CreateModel.BrandOptions;

                page.CreateModel = model;

                return View("Index", page);
            }

            var created = await modelAdminService.CreateAsync(model);

            if (!created)
            {
                ModelState.AddModelError(
                    nameof(model.Name),
                    "Ce modèle existe déjà pour cette marque."
                );

                var page = await modelAdminService.GetIndexModelAsync();

                model.BrandOptions = page.CreateModel.BrandOptions;

                page.CreateModel = model;

                return View("Index", page);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModelFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var page = await modelAdminService.GetIndexModelAsync();

                model.BrandOptions = page.CreateModel.BrandOptions;

                page.EditModel = model;

                return View("Index", page);
            }

            var updated = await modelAdminService.UpdateAsync(model);

            if (!updated)
            {
                ModelState.AddModelError(
                    nameof(model.Name),
                    "Ce modèle existe déjà pour cette marque."
                );

                var page = await modelAdminService.GetIndexModelAsync();

                model.BrandOptions = page.CreateModel.BrandOptions;

                page.EditModel = model;

                return View("Index", page);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await modelAdminService.DeleteAsync(id);

            if (!deleted)
            {
                TempData["Error"] = "Ce modèle ne peut pas être supprimé car il est utilisé.";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
