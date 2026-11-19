using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Controllers
{
    public class VehicleListingsController(
        IVehicleListingService vehicleListingService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var listing = await vehicleListingService.GetDetailsByIdAsync(id);

            if (listing is null) return NotFound();

            return View(listing);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await vehicleListingService.GetEditModelAsync(id);

            if (model is null) return NotFound();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleListingEditViewModel model)
        {
            if (id != model.ListingId) return BadRequest();
            if (!ModelState.IsValid)
            {
                model.RepairTypeOptions = [..await vehicleListingService.GetRepairTypeOptionsAsync()];
                return View(model);
            }

            var updated = await vehicleListingService.UpdateAsync(id, model);

            if (!updated) return NotFound();

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await vehicleListingService.GetDetailsByIdAsync(id);

            if (model is null) return NotFound();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleted = await vehicleListingService.DeleteAsync(id);

            if (!deleted) return NotFound();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
