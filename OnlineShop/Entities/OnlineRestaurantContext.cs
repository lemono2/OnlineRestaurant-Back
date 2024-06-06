using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Dtos;

namespace OnlineShop.Entities;

public partial class OnlineRestaurantContext : DbContext
{
    public OnlineRestaurantContext()
    {
    }

    public OnlineRestaurantContext(DbContextOptions<OnlineRestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

   //public virtual DbSet<BasketDto> BasketDtos { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(p => p.ProductId);

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Basktets__Produc__403A8C7D");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B588CED5D");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDEC6FFC77");

            entity.Property(e => e.ProductImage)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.ProductPrice).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
