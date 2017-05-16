using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Configurations;
using System;
using System.Data.Entity;

namespace Hk.Application1.Data.Models
{
    public partial class DatabaseContext : DbContext, IDisposable
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DatabaseContext()
            : base("Name=OrderMgmtContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order_Detail> Order_Details { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new Order_DetailConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
