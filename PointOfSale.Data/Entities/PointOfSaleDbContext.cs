using System.IO;
using System.Linq;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PointOfSale.Data.Entities
{
    public class PointOfSaleDbContext : DbContext
    {
        public PointOfSaleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OneOffBill> OneOffBills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceBill> ServiceBills { get; set; }
        public DbSet<SubscriptionBill> SubscriptionBills { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<CategoryOffer> CategoryOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataBaseSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class PointOfSaleContextFactory : IDesignTimeDbContextFactory<PointOfSaleDbContext>
    { 
            public PointOfSaleDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config")
                    .Build();
                configuration
                    .Providers
                    .First()
                    .TryGet("connectionStrings:add:PointOfSale:connectionString", out var connectionString);

                var options = new DbContextOptionsBuilder<PointOfSaleDbContext>().UseSqlServer(connectionString).Options;
                return new PointOfSaleDbContext(options);
            }
        
    }
}
