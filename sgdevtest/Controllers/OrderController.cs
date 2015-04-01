using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sgdal.Models;
using sgdevtest.Models;
using sgdal;

namespace sgdevtest.Controllers
{
    public class OrderController : Controller
    {
        private SgContext db = new SgContext();

        public ActionResult Index(OrderSearch search)
        {
            var searchItem = Search(search);
        
            ViewBag.OrderSearch = search;

            return View(searchItem.ToList());
        }
        //
        private IQueryable<OrderItemViewModel> Search(OrderSearch search)
        {//
            var orderItem = from oi in db.OrderItems
                            join p in db.Products on oi.ProductID equals p.ID
                            group new { oi, p } by new { oi.OrderID } into grp
                            join o in db.Orders on grp.Key.OrderID equals o.ID
                            join c in db.Customers on o.CustomerID equals c.ID
                            orderby grp.Key.OrderID
                            select new OrderItemViewModel
                            {
                                OrderItemID = grp.Key.OrderID,
                                Date = o.Date,
                                CustomerName = c.Lastname + ", " + c.Firstname,
                                Count = grp.Sum(g => g.oi.Count),
                                Total = grp.Sum(g => g.p.Price),
                                Products = grp.Select(s => s.p.Name).ToList()
                            };

            var searchItem = orderItem;

            switch (search.SortField)
            {
                case "OrderItemID":
                    searchItem = (search.SortDirection == "ascending" ?
                        orderItem.OrderBy(s => s.OrderItemID) :
                        orderItem.OrderByDescending(s => s.OrderItemID));
                    break;
                case "Date":
                    searchItem = (search.SortDirection == "ascending" ?
                        orderItem.OrderBy(s => s.Date) :
                        orderItem.OrderByDescending(s => s.Date));
                    break;
                case "CustomerName":
                    searchItem = (search.SortDirection == "ascending" ?
                        orderItem.OrderBy(s => s.CustomerName) :
                        orderItem.OrderByDescending(s => s.CustomerName));
                    break;
                case "Count":
                    searchItem = (search.SortDirection == "ascending" ?
                        orderItem.OrderBy(s => s.Count) :
                        orderItem.OrderByDescending(s => s.Count));
                    break;
                case "Total":
                    searchItem = (search.SortDirection == "ascending" ?
                        orderItem.OrderBy(s => s.Total) :
                        orderItem.OrderByDescending(s => s.Total));
                    break;
            }

            var idSearchVal = default(int);
            var isIdSearchInt = int.TryParse(search.IdSearch, out idSearchVal);
            if (!string.IsNullOrWhiteSpace(search.IdSearch) && isIdSearchInt)
            {
                searchItem = searchItem.Where(s => s.OrderItemID == idSearchVal);
            }

            if (!string.IsNullOrWhiteSpace(search.CustomerSearch))
            {
                searchItem = searchItem.Where(s => s.CustomerName == search.CustomerSearch);
            }

            var totalSearchVal = default(int);
            var isTotalSearchInt = int.TryParse(search.TotalSearch, out totalSearchVal);
            if (!string.IsNullOrWhiteSpace(search.TotalSearch) && isTotalSearchInt)
            {
                searchItem = searchItem.Where(s => s.Total == totalSearchVal);
            }

            if (!string.IsNullOrWhiteSpace(search.ProductSearch))
            {
                searchItem = searchItem.Where(s => s.Products.Any(p => p == search.ProductSearch));
            }

            return searchItem;
        }


        //
        // GET: /Order/Details/5
        public ActionResult Details(int id)
        {
            var orderItem = from oi in db.OrderItems
                            join p in db.Products on oi.ProductID equals p.ID
                            group new { oi, p } by new { oi.OrderID } into grp
                            join o in db.Orders on grp.Key.OrderID equals o.ID
                            join c in db.Customers on o.CustomerID equals c.ID
                            where o.ID == id
                            select new OrderDetailViewModel
                            {
                                OrderItemID = grp.Key.OrderID,
                                Date = o.Date,
                                CustomerName = c.Lastname + ", " + c.Firstname,
                                Total = grp.Sum(g => g.p.Price * g.oi.Count),
                                Products = grp.Select(g => 
                                    new ProductDetail 
                                    {
                                    Count = g.oi.Count, 
                                    Name = g.p.Name, 
                                    Price = g.p.Price,
                                    SubTotal = g.p.Price * g.oi.Count
                            }).ToList()
                            };

            return View(orderItem.FirstOrDefault());
        }
    }
}
