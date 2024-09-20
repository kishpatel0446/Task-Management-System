using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    // Controller for handling home page requests
    public class HomeController : Controller
    {
        // Logger instance for logging events and errors
        private readonly ILogger<HomeController> _logger;

        // Constructor for the home controller, injecting the logger instance
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action for handling the home page request
        public IActionResult Index()
        {
            // Returns the view for the home page
            return View();
        }

        // Action for handling the privacy page request
        public IActionResult Privacy()
        {
            // Returns the view for the privacy page
            return View();
        }

        // Action for handling error requests, with response caching disabled
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Creates an error view model with the request ID
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            // Returns the error view with the error view model
            return View(errorViewModel);
        }
    }
}