using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrilPractika.Models
{
    public partial class ChichikinKarsheringContext : DbContext
    {
        public ChichikinKarsheringContext()
        {
        }

        public ChichikinKarsheringContext(DbContextOptions<ChichikinKarsheringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<CarSharingPrice> CarSharingPrices { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Fine> Fines { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TotalPrice> TotalPrices { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=81.177.6.104, 1433; Database=ChichikinKarshering; User ID=is221; Password =Student1234; Trusted_Connection=False; Integrated Security=False; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.ToTable("Auto");

                entity.Property(e => e.CarStateNumber).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.InsuranceValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.PricePerMinute).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CarSharingPrice>(entity =>
            {
                entity.ToTable("CarSharingPrice");

                entity.HasOne(d => d.IdDiscountNavigation)
                    .WithMany(p => p.CarSharingPrices)
                    .HasForeignKey(d => d.IdDiscount)
                    .HasConstraintName("FK_CarSharingPrice_Discount");

                entity.HasOne(d => d.IdRentalNavigation)
                    .WithMany(p => p.CarSharingPrices)
                    .HasForeignKey(d => d.IdRental)
                    .HasConstraintName("FK_CarSharingPrice_Rental");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.DrivingLicenseData).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(90);

                entity.Property(e => e.PassportData).HasMaxLength(50);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Client_User");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PercentDiscount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("Fine");

                entity.Property(e => e.FineAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("Rental");

                entity.Property(e => e.RentalEndDate).HasColumnType("datetime");

                entity.Property(e => e.RentalStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.IdAuto)
                    .HasConstraintName("FK_Rental_Auto");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Rental_Client");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TotalPrice>(entity =>
            {
                entity.ToTable("TotalPrice");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCarSharingPriceNavigation)
                    .WithMany(p => p.TotalPrices)
                    .HasForeignKey(d => d.IdCarSharingPrice)
                    .HasConstraintName("FK_TotalPrice_CarSharingPrice");

                entity.HasOne(d => d.IdFineNavigation)
                    .WithMany(p => p.TotalPrices)
                    .HasForeignKey(d => d.IdFine)
                    .HasConstraintName("FK_TotalPrice_Fine");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
