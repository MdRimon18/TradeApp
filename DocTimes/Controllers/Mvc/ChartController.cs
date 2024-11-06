using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers.Mvc
{
    public class ChartController : Controller
    {
        public IActionResult Index(bool isPartial = false)
        {
            // If the request is an AJAX request, return the partial view only
            //if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView("Index");
            //}
            if (isPartial)
            {
                return PartialView("Index");
            }
            return View("Index");

        }
    }
}
