using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
