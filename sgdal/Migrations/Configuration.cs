namespace sgdal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using sgdal.Models;
    using sgdal;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<sgdal.SgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(sgdal.SgContext context)
        {
            var customer = new List<Customer>
            {
                new Customer{ID=1,Firstname="John 1",Lastname="Doe"},
                new Customer{ID=2,Firstname="John 2",Lastname="Doe"},
                new Customer{ID=3,Firstname="John 3",Lastname="Doe"},
                new Customer{ID=4,Firstname="John 4",Lastname="Doe"}
            };
            customer.ForEach(p => context.Customers.AddOrUpdate(c => c.ID, p));
            context.SaveChanges();

            var product = new List<Product>
            {
                new Product{ID=1,Name="Product 1",Price=1.34M},
                new Product{ID=2,Name="Product 2",Price=123.123M},
                new Product{ID=3,Name="Product 3",Price=1123M},
                new Product{ID=4,Name="Product 4",Price=123123.01M}
            };
            product.ForEach(p => context.Products.AddOrUpdate(c => c.ID, p));
            context.SaveChanges();

            var order = new List<Order>
            {
                new Order{ID=1,CustomerID=1,Date = DateTime.Now.AddDays(-1)},
                new Order{ID=2,CustomerID=2,Date = DateTime.Now.AddDays(-2)},
                new Order{ID=3,CustomerID=3,Date = DateTime.Now.AddDays(-4)},
                new Order{ID=4,CustomerID=1,Date = DateTime.Now.AddDays(-5)}
            };
            order.ForEach(o => context.Orders.AddOrUpdate(c => c.ID, o));
            context.SaveChanges();

            var orderItem = new List<OrderItem>
            {
                new OrderItem { ID = 1, OrderID=1, ProductID=1, Count=1},
                new OrderItem { ID = 2, OrderID=1, ProductID=2, Count=2},
                new OrderItem { ID = 3, OrderID=1, ProductID=4, Count=4},
                new OrderItem { ID = 4, OrderID=2, ProductID=1, Count=61},
                new OrderItem { ID = 5, OrderID=3, ProductID=1, Count=1},
                new OrderItem { ID = 6, OrderID=3, ProductID=2, Count=4},
                new OrderItem { ID = 7, OrderID=4, ProductID=4, Count=1},

            };
            orderItem.ForEach(oI => context.OrderItems.AddOrUpdate(c => c.ID, oI));
            context.SaveChanges();
        }
    }
}
