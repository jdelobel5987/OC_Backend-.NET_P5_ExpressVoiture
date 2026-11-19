using ExpressVoiture.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            // List all brands
            return View();
        }

        public IActionResult Create()
        {
            // Form to create a new brand
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult Create(CreateBrandViewModel model)
        //{
        //    // Create a new brand based on the submitted model

        //    // Return a success message
        //    var result = ""; // Replace with actual result message
        //    return RedirectToAction("Index", new { message = result });
        //}
    }
}
