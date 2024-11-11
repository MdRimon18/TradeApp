using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using TradeApp.Services.Inventory;

namespace TradeApp.Controllers.Mvc.Product
{
    public class ProductSerialNumberController : Controller
    {
        private readonly ProductSerialNumbersService _productSerialNumbersService;

        public ProductSerialNumberController(ProductSerialNumbersService productSerialNumbersService)
        {
            _productSerialNumbersService = productSerialNumbersService;
        }

        public async Task<IActionResult> Index(bool isPartial = false,int currentPage = 1, int pageSize = 5, string prodSerialNumber="")
        {
            var viewModel = new ProductSerialNumbersViewModel
            {
                ProdSerialNmbr = prodSerialNumber,
                PageSize = pageSize,
                CurrentPage = currentPage
            };

            await LoadProductSerialNumbers(viewModel);

            if (isPartial)
            {
                return PartialView("Index", viewModel);
            }
            return View("Index", viewModel);

        }

        private async Task LoadProductSerialNumbers(ProductSerialNumbersViewModel viewModel)
        {
            try
            {
                // If `ProdSerialNmbr` is an empty string, treat it as null
                if (string.IsNullOrEmpty(viewModel.ProdSerialNmbr))
                {
                    viewModel.ProdSerialNmbr = null;
                }

                // Fetch data using the service
                viewModel.ProductSerialNumberList = (await _productSerialNumbersService
                    .Get(null, null, null, viewModel.ProdSerialNmbr, null, null, null, null, null, null, null, viewModel.CurrentPage, viewModel.PageSize))
                    .ToList();

                // Update total records and total pages
                if (viewModel.ProductSerialNumberList.Count > 0)
                {
                    viewModel.TotalRecord = viewModel.ProductSerialNumberList[0].total_row;
                    viewModel.TotalPages = (int)Math.Ceiling((double)viewModel.TotalRecord / viewModel.PageSize);
                }
                else
                {
                    viewModel.TotalRecord = 0;
                    viewModel.TotalPages = 0;
                }
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.Message;
            }
            finally
            {
                viewModel.IsLoading = false;
            }
        }
    }
}
