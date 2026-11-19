using ExpressVoiture.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoiture.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            // List all models
            return View();
        }

        public IActionResult Create()
        {
            // Form to create a new model
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult Create(CreateModelViewModel model)
        //{
        //    // Create a new model based on the submitted model

        //    // Return a success message
        //    var result = ""; // Replace with actual result message
        //    return RedirectToAction("Index", new { message = result });
        //}
    }
}
