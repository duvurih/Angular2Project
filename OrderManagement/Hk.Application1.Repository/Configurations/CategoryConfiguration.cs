﻿using Hk.Application1.Core.Models;

namespace Hk.Application1.Repository.Configurations
{
    public class CategoryConfiguration : EntityBaseConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Picture).HasColumnName("Picture");
        }
    }
}

