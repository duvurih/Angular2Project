using Hk.Application1.Core.Models;

namespace Hk.Application1.Repository.Configurations
{
    public class ShipperConfiguration : EntityBaseConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ShipperID);

            // Properties
            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.Phone)
                .HasMaxLength(24);

            // Table & Column Mappings
            this.ToTable("Shippers");
            this.Property(t => t.ShipperID).HasColumnName("ShipperID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Phone).HasColumnName("Phone");
        }
    }
}
