using System.Diagnostics;
using ExpressVoiture.Interfaces;
using ExpressVoiture.Models;
using ExpressVoiture.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Controllers
{
    public class HomeController(
        IVehicleListingService vehicleListingService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var inventory = await vehicleListingService.GetAvailableAsync();
            return View(inventory);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
