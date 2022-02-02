using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GrpcService.Models
{
    public partial class BlazorContext : DbContext
    {
        public BlazorContext()
        {
        }

        public BlazorContext(DbContextOptions<BlazorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionsStringsDetail> ConnectionsStringsDetails { get; set; }
        public virtual DbSet<EnvironmentsDetail> EnvironmentsDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blazor;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionsStringsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ConnectionsStringsDetail");

                entity.Property(e => e.ApplicationCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.KeyCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Value)
                    .HasMaxLength(4096)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnvironmentsDetail>(entity =>
            {
                entity.ToTable("EnvironmentsDetail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductRowId)
                    .HasName("PK__Products__2F7036E1227A39DC");

                entity.HasIndex(e => e.ProductId, "UQ__Products__B40CC6CC943DE749")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
