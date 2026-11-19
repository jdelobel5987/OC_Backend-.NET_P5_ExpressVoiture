using ExpressVoiture.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController(
        IAdminDashboardService adminDashboardService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? selectedVehicleId)
        {
            var model = await adminDashboardService.GetDashboardAsync(selectedVehicleId);
            return View(model);
        }

    }
}
