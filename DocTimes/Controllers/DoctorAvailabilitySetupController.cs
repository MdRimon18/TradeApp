using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers
{
    public class DoctorAvailabilitySetupController : Controller
    {
        public IActionResult WeeklyPlan(int? id)
        {
            // If the request is an AJAX request, return the partial view only
            //if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView("WeeklyPlan");
            //}

            return PartialView("WeeklyPlan");  // Full view if not an AJAX request
           
        }
    }
}
