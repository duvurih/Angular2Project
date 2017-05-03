﻿using Hk.Application1.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Hk.Application1.Repository.Configurations
{
    public class Summary_of_Sales_by_YearMap : EntityTypeConfiguration<Summary_of_Sales_by_Year>
    {
        public Summary_of_Sales_by_YearMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Summary of Sales by Year");
            this.Property(t => t.ShippedDate).HasColumnName("ShippedDate");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.Subtotal).HasColumnName("Subtotal");
        }
    }
}
