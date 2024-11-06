using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers
{
    public class WorkStatusController : Controller
    {
        public IActionResult Progress(int? id, bool isPartial = false)
        {
            ViewData["Id"] = id; // Pass the ID to the view if needed
            if (isPartial)
            {
                return PartialView("Progress");
            }
            return View("Progress");
        }
    }
}
