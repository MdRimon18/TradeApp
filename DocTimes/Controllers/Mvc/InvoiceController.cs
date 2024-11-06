using Microsoft.AspNetCore.Mvc;

namespace TradeApp.Controllers.Mvc
{
    public class InvoiceController : Controller
    {
        public IActionResult Create(bool isPartial = false)
        {
            
            if (isPartial)
            {
                return PartialView("Create");
            }
            return View("Create");

        }
    }
}
