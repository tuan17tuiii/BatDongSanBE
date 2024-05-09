using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Batdongsan> Batdongsans { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ImageBatdongsan> ImageBatdongsans { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TypeBatdongsan> TypeBatdongsans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VPOBRTF;Database=BatDongSan;user id=sa;password=123456;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.ToTable("advertisement");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdvertisementName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("advertisement_name");
            entity.Property(e => e.Describe)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("describe");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<Batdongsan>(entity =>
        {
            entity.ToTable("batdongsan");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Acreage).HasColumnName("acreage");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.CityIt).HasColumnName("city_it");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Describe)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("describe");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserbuyId).HasColumnName("userbuy_id");
            entity.Property(e => e.UsersellId).HasColumnName("usersell_id");
            entity.Property(e => e.WardId).HasColumnName("ward_id");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Batdongsans)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_batdongsan_type_batdongsan");

            entity.HasOne(d => d.Userbuy).WithMany(p => p.BatdongsanUserbuys)
                .HasForeignKey(d => d.UserbuyId)
                .HasConstraintName("FK_batdongsan_user1");

            entity.HasOne(d => d.Usersell).WithMany(p => p.BatdongsanUsersells)
                .HasForeignKey(d => d.UsersellId)
                .HasConstraintName("FK_batdongsan_user2");

            entity.HasOne(d => d.Ward).WithMany(p => p.Batdongsans)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK_batdongsan_ward");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CityName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BatdongsanId).HasColumnName("batdongsan_id");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_comment_user");
        });

        modelBuilder.Entity<ImageBatdongsan>(entity =>
        {
            entity.ToTable("image_batdongsan");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BatdongsanId).HasColumnName("batdongsan_id");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url_image");

            entity.HasOne(d => d.Batdongsan).WithMany(p => p.ImageBatdongsans)
                .HasForeignKey(d => d.BatdongsanId)
                .HasConstraintName("FK_image_batdongsan_batdongsan");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("region");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.RegionName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("region_name");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("FK_region_city");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.ToTable("street");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.StreetName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("street_name");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("FK_street_region");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transaction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.IdBatdongsan).HasColumnName("id_batdongsan");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("transaction_type");

            entity.HasOne(d => d.Buyer).WithMany(p => p.TransactionBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_transaction_user");

            entity.HasOne(d => d.IdBatdongsanNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IdBatdongsan)
                .HasConstraintName("FK_transaction_batdongsan");

            entity.HasOne(d => d.Seller).WithMany(p => p.TransactionSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_transaction_user1");
        });

        modelBuilder.Entity<TypeBatdongsan>(entity =>
        {
            entity.ToTable("type_batdongsan");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdvertisementId).HasColumnName("advertisement_id");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Advertisement).WithMany(p => p.Users)
                .HasForeignKey(d => d.AdvertisementId)
                .HasConstraintName("FK_user_advertisement");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_user_role");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.ToTable("ward");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.WardName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ward_name");

            entity.HasOne(d => d.IdStreetNavigation).WithMany(p => p.Wards)
                .HasForeignKey(d => d.IdStreet)
                .HasConstraintName("FK_ward_street");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
