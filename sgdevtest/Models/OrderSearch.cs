using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgdevtest.Models
{
    public class OrderSearch
    {
        public string SortField { get; set; }
        public string SortDirection { get; set; }

        public string IdSearch { get; set; }
        public string ProductSearch  { get; set; }
        public string CustomerSearch { get; set; }
        public string CountSearch { get; set; }
        public string TotalSearch { get; set; }
    }
}