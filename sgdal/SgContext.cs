using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using sgdal.Models;

namespace sgdal
{
    public class SgContext : DbContext
    {
        public SgContext()
            : base("SgContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SgContext, sgdal.Migrations.Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}