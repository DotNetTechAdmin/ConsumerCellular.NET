using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsumerCellular.NET.Models
{
    public partial class ConsumerCellularContext : DbContext
    {
        public ConsumerCellularContext()
        {
        }

        public ConsumerCellularContext(DbContextOptions<ConsumerCellularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CellPhone> CellPhones { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductColor> ProductColors { get; set; } = null!;
        public virtual DbSet<ProductOwnership> ProductOwnerships { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=sqldb-consumercellular;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellPhone>(entity =>
            {
                entity.ToTable("CellPhone");

                entity.Property(e => e.CellPhoneId).HasColumnName("CellPhoneID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CellPhones)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_CellPhone");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PriceAcquisition).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.PricePerMonth).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ProductOwnerId).HasColumnName("ProductOwnerID");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.HasOne(d => d.ProductOwner)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductOwnership_Product");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductType_Product");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.ToTable("ProductColor");

                entity.Property(e => e.ProductColorId).HasColumnName("ProductColorID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ProductOwnershipId).HasColumnName("ProductOwnershipID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Color_ProductColor");

                entity.HasOne(d => d.ProductOwnership)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductOwnership_ProductColor");
            });

            modelBuilder.Entity<ProductOwnership>(entity =>
            {
                entity.ToTable("ProductOwnership");

                entity.Property(e => e.ProductOwnershipId).HasColumnName("ProductOwnershipID");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
