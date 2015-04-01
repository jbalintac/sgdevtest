using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgdal.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Count { get; set; }
    }
}