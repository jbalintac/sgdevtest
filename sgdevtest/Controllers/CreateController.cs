using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sgdevtest.Models;
using sgdal;

namespace sgdevtest.Controllers
{
    public class CreateController : Controller
    {
        private SgContext db = new SgContext();

        // GET: Create
        public ActionResult Index()
        {
            var createViewModel = new CreateViewModel
            {
                Customers = db.Customers.Select(c => new { ID = c.ID, Name = c.Lastname + ", " + c.Firstname }).ToDictionary(c => c.ID, c => c.Name),
                Products = db.Products.Select(c => new { ID = c.ID, Name = c.Name }).ToDictionary(c => c.ID, c => c.Name)
            };

            return View(createViewModel);
        }

        public ActionResult New(NewOrderModel order)
        {
            var newOrder = new sgdal.Models.Order()
            {
                Date = DateTime.Now,
                CustomerID = order.CustomerID,
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();

            foreach (var item in order.Products)
            {
                db.OrderItems.Add(new sgdal.Models.OrderItem { OrderID = newOrder.ID, ProductID = item.ID, Count = item.Count });
                db.SaveChanges();
            }
            return Json(new { Redirect = "/order/details/" + newOrder.ID});
        }
    }
}
