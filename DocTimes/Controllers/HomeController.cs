using DocTimes.Models;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;

namespace DocTimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {

            return View();

        }
        //[Route("{route?}")]
        //public IActionResult Index(string route, int? id = null)
        //{
        //    var routingHelper = new RoutingHelper
        //    {
        //        RouteName = route,
        //        IsShow = true
        //    };

        //    // If the request is an AJAX request, return the partial view only
        //    if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        return PartialView(route); // Serve just the partial if requested via AJAX
        //    }

        //    return PartialView(routingHelper); // Loads the default view if no route is specified
        //}


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
