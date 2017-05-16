using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models.Mapping;
using System.Data.Entity;

namespace Hk.Application1.Data.Models
{
    public partial class OrderMgmtContext : DbContext
    {
        static OrderMgmtContext()
        {
            Database.SetInitializer<OrderMgmtContext>(null);
        }

        public OrderMgmtContext()
            : base("Name=OrderMgmtContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new Order_DetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SupplierMap());
        }
    }
}
