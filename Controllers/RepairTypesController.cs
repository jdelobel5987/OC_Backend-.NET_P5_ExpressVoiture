using ExpressVoiture.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Controllers
{
    public class RepairTypesController : Controller
    {
        public IActionResult Index()
        {
            // List all repair types
            return View();
        }

        public IActionResult Create()
        {
            // Form to create a new repair type
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult Create(CreateRepairTypeViewModel model)
        //{
        //    // Create a new repair type based on the submitted model

        //    // Return a success message
        //    var result = ""; // Replace with actual result message
        //    return RedirectToAction("Index", new { message = result });
        //}
    }
}
