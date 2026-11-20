using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.Entities;
using ExpressVoiture.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandsController(
        IBrandAdminService brandAdminService) 
        : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? editId)
        {
            var model = await brandAdminService.GetIndexModelAsync(editId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var page = await brandAdminService.GetIndexModelAsync();

                page.CreateModel = model;

                return View("Index", page);
            }

            var created = await brandAdminService.CreateAsync(model);

            if (!created)
            {
                ModelState.AddModelError(
                    nameof(model.Name),
                    "Une marque portant ce nom existe déjà."
                );

                var page = await brandAdminService.GetIndexModelAsync();

                return View("Index", page);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var page = await brandAdminService.GetIndexModelAsync();

                page.EditModel = model;

                return View("Index", page);
            }

            var updated = await brandAdminService.UpdateAsync(model);

            if (!updated)
            {
                ModelState.AddModelError(
                    nameof(model.Name),
                    "Le nom existe déjà ou la marque est introuvable."
                );

                var page = await brandAdminService.GetIndexModelAsync();

                page.EditModel = model;

                return View("Index", page);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await brandAdminService.DeleteAsync(id);

            if (!deleted)
            {
                TempData["Error"] = "Cette marque ne peut pas être supprimée car elle est utilisée.";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
