using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgdal.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
    }
}