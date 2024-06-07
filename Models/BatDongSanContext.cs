using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Models;

public partial class BatDongSanContext : DbContext
{
    public BatDongSanContext()
    {
    }

    public BatDongSanContext(DbContextOptions<BatDongSanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ImageRealestate> ImageRealestates { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Realestate> Realestates { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TypeRealestate> TypeRealestates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.ToTable("advertisement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdvertisementName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("advertisement_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantitydate).HasColumnName("quantitydate");
            entity.Property(e => e.Quantitynews).HasColumnName("quantitynews");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
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

        modelBuilder.Entity<ImageRealestate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_image_batdongsan");

            entity.ToTable("image_realestate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Newsid).HasColumnName("newsid");
            entity.Property(e => e.RealestateId).HasColumnName("realestate_id");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url_image");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.News).WithMany(p => p.ImageRealestates)
                .HasForeignKey(d => d.Newsid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_image_realestate_news");

            entity.HasOne(d => d.Realestate).WithMany(p => p.ImageRealestates)
                .HasForeignKey(d => d.RealestateId)
                .HasConstraintName("FK_image_batdongsan_batdongsan");

            entity.HasOne(d => d.User).WithMany(p => p.ImageRealestates)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_image_realestate_user");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.ToTable("news");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Tag)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tag");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Realestate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_batdongsan");

            entity.ToTable("realestate	");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acreage).HasColumnName("acreage");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedEnd).HasColumnName("created_end");
            entity.Property(e => e.Describe)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("describe");
            entity.Property(e => e.Expired).HasColumnName("expired");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Region)
                .HasMaxLength(250)
                .HasColumnName("region");
            entity.Property(e => e.Sold).HasColumnName("sold");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Street)
                .HasMaxLength(250)
                .HasColumnName("street");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transaction_type");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UsersellId).HasColumnName("usersell_id");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Realestates)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_batdongsan_type_batdongsan");

            entity.HasOne(d => d.Usersell).WithMany(p => p.Realestates)
                .HasForeignKey(d => d.UsersellId)
                .HasConstraintName("FK_batdongsan_user2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.RealestateId).HasColumnName("realestate_id");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");

            entity.HasOne(d => d.Buyer).WithMany(p => p.TransactionBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_transaction_user");

            entity.HasOne(d => d.Realestate).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.RealestateId)
                .HasConstraintName("FK_transaction_batdongsan");

            entity.HasOne(d => d.Seller).WithMany(p => p.TransactionSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_transaction_user1");
        });

        modelBuilder.Entity<TypeRealestate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_type_batdongsan");

            entity.ToTable("type_realestate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasIndex(e => e.Username, "NonClusteredIndex-20240510-180547").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdvertisementId).HasColumnName("advertisement_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("avatar");
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
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("securityCode");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Statusupdate)
                .HasDefaultValue(false)
                .HasColumnName("statusupdate");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
