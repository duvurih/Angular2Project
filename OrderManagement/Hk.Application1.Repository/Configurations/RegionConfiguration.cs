using Hk.Application1.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hk.Application1.Repository.Configurations
{
    public class RegionConfiguration : EntityBaseConfiguration<Region>
    {
        public RegionConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.RegionID);

            // Properties
            this.Property(t => t.RegionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RegionDescription)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.RegionDescription).HasColumnName("RegionDescription");
        }
    }
}
