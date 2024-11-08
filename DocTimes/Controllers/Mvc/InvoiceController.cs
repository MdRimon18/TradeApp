using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace TradeApp.Controllers.Mvc
{
    public class InvoiceController : Controller
    {
        public IActionResult Create(bool isPartial = false)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            if (isPartial)
            {
                return PartialView("Create", invoiceViewModel);
            }
            return View("Create", invoiceViewModel);

        }
        public IActionResult Index(bool isPartial = false)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            if (isPartial)
            {
                return PartialView("Index", invoiceViewModel);
            }
            return View("Index", invoiceViewModel);

        }
    }
}
