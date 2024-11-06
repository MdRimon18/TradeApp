using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Payment()
        {
            // If the request is an AJAX request, return the partial view only
            //if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView("Payment");
            //}

            return PartialView("Payment");

        }
         
    }
}
