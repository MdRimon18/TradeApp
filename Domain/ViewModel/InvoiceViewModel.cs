using Domain.Entity.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceItems> ItemsList { get; set; } = new List<InvoiceItems>();
        public List<Products> Products { get; set; } = new List<Products>();
        public List<Products> FilteredItemsOffCanva=new List<Products>();
        public List<NotificationBy> NotificationByList { get; set; }
        public List<InvoiceType> InvoiceTypeList { get; set; }
        public List<ProductCategories> ProductCategoryList { get; set; }
        public List<ProductSubCategory> ProductSubCategoryList { get; set; }
        public List<PaymentTypes> PaymentTypesList { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<ProductSerialNumbers> SerialNumbers { get; set; }
        public List<ProductSerialNumbers> SelectedSerialNumbers { get; set; }
        public string CustomerEmail { get; set; }
        public string SearchQuery { get; set; }
        public string SrchQuery { get; set; }
    }

}
