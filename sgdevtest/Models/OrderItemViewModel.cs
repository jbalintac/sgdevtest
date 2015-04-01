using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using sgdal.Models;

namespace sgdevtest.Models
{
    public class OrderItemViewModel
    {
        [Display(Name = "Order Number")]
        public int OrderItemID { get; set; }

        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Item Count")]
        public int Count { get; set; }

        [Display(Name = "Order Total")]
        public decimal Total { get; set; }

        [Display(Name = "Products")]
        public List<string> Products { get; set; }
    }

    public class OrderDetailViewModel
    {
        [Display(Name = "Order Number")]
        public int OrderItemID { get; set; }

        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Order Total")]
        public decimal Total { get; set; }

        [Display(Name = "Products")]
        public List<ProductDetail> Products { get; set; }
    }

    public class ProductDetail
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal SubTotal { get; set; }
    }
}