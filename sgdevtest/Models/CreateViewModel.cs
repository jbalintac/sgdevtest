using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sgdal.Models;

namespace sgdevtest.Models
{
    public class CreateViewModel
    {
        public IDictionary<int, string> Products { get; set; }
        public IDictionary<int, string> Customers { get; set; }
    }

    public class NewOrderModel
    {
        public List<ProductViewModel> Products { get; set; }
        public int CustomerID { get; set; }
    }

    public class ProductViewModel
    {
        public int ID { get; set; }
        public int Count { get; set; }
    }
}