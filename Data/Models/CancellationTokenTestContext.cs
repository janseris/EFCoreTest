﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class CancellationTokenTestContext : DbContext
    {
        public CancellationTokenTestContext()
        {
        }

        public CancellationTokenTestContext(DbContextOptions<CancellationTokenTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IMAGE> IMAGE { get; set; }
        public virtual DbSet<IMAGE_DATA> IMAGE_DATA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Czech_100_CI_AS");

            modelBuilder.Entity<IMAGE>(entity =>
            {
                entity.HasComment("Test table for EF Core Cancellation Token");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IMAGE_DATA>(entity =>
            {
                entity.HasKey(e => e.ImageID);

                entity.HasIndex(e => e.FS_GUID, "UQ__IMAGE_DA__A4DC574A3112DD14")
                    .IsUnique();

                entity.Property(e => e.ImageID).ValueGeneratedNever();

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.FS_GUID).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.IMAGE_DATA)
                    .HasForeignKey<IMAGE_DATA>(d => d.ImageID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IMAGE_DATA_IMAGE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}