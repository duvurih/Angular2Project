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
            : base("Name=NORTHWNDContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Order_Detail> Order_Details { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Shipper> Shippers { get; set; }
        public IDbSet<Supplier> Suppliers { get; set; }
        public IDbSet<sysdiagram> sysdiagrams { get; set; }
        public IDbSet<Territory> Territories { get; set; }
        //public IDbSet<Alphabetical_list_of_product> Alphabetical_list_of_products { get; set; }
        //public IDbSet<Category_Sales_for_1997> Category_Sales_for_1997 { get; set; }
        //public IDbSet<Current_Product_List> Current_Product_Lists { get; set; }
        //public IDbSet<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities { get; set; }
        //public IDbSet<Invoice> Invoices { get; set; }
        //public IDbSet<Order_Details_Extended> Order_Details_Extendeds { get; set; }
        //public IDbSet<Order_Subtotal> Order_Subtotals { get; set; }
        //public IDbSet<Orders_Qry> Orders_Qries { get; set; }
        //public IDbSet<Product_Sales_for_1997> Product_Sales_for_1997 { get; set; }
        //public IDbSet<Products_Above_Average_Price> Products_Above_Average_Prices { get; set; }
        //public IDbSet<Products_by_Category> Products_by_Categories { get; set; }
        //public IDbSet<Sales_by_Category> Sales_by_Categories { get; set; }
        //public IDbSet<Sales_Totals_by_Amount> Sales_Totals_by_Amounts { get; set; }
        //public IDbSet<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters { get; set; }
        //public IDbSet<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CustomerDemographicConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new Order_DetailConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TerritoryConfiguration());
            //modelBuilder.Configurations.Add(new Alphabetical_list_of_productMap());
            //modelBuilder.Configurations.Add(new Category_Sales_for_1997Map());
            //modelBuilder.Configurations.Add(new Current_Product_ListMap());
            //modelBuilder.Configurations.Add(new Customer_and_Suppliers_by_CityMap());
            //modelBuilder.Configurations.Add(new InvoiceConfiguration());
            //modelBuilder.Configurations.Add(new Order_Details_ExtendedMap());
            //modelBuilder.Configurations.Add(new Order_SubtotalMap());
            //modelBuilder.Configurations.Add(new Orders_QryMap());
            //modelBuilder.Configurations.Add(new Product_Sales_for_1997Map());
            //modelBuilder.Configurations.Add(new Products_Above_Average_PriceMap());
            //modelBuilder.Configurations.Add(new Products_by_CategoryMap());
            //modelBuilder.Configurations.Add(new Sales_by_CategoryMap());
            //modelBuilder.Configurations.Add(new Sales_Totals_by_AmountMap());
            //modelBuilder.Configurations.Add(new Summary_of_Sales_by_QuarterMap());
            //modelBuilder.Configurations.Add(new Summary_of_Sales_by_YearMap());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
