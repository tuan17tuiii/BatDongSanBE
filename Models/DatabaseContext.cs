﻿using System;
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

    public virtual DbSet<ImageRealestate> ImageRealestates { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Realestate> Realestates { get; set; }

    public virtual DbSet<Remain> Remains { get; set; }

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
                .HasConstraintName("FK_image_realestate_news");

            entity.HasOne(d => d.Realestate).WithMany(p => p.ImageRealestates)
                .HasForeignKey(d => d.RealestateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_image_batdongsan_batdongsan");

            entity.HasOne(d => d.User).WithMany(p => p.ImageRealestates)
                .HasForeignKey(d => d.Userid)
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
            entity.Property(e => e.Statusupdate).HasColumnName("statusupdate");
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

        modelBuilder.Entity<Remain>(entity =>
        {
            entity.ToTable("remain");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdend).HasColumnName("createdend");
            entity.Property(e => e.IdAdv).HasColumnName("id_adv");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Remaining).HasColumnName("remaining");

            entity.HasOne(d => d.IdAdvNavigation).WithMany(p => p.Remains)
                .HasForeignKey(d => d.IdAdv)
                .HasConstraintName("FK_remain_advertisement");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Remains)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_remain_user");
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
            entity.HasKey(e => e.Id).HasName("PK_transaction_1");

            entity.ToTable("transaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.IdAdv).HasColumnName("id_adv");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdAdvNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IdAdv)
                .HasConstraintName("FK_transaction_advertisement");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_transaction_user2");
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
            entity.Property(e => e.Statusupdate).HasColumnName("statusupdate");
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
