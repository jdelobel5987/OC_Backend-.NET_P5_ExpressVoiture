using ExpressVoiture.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Model> Models => Set<Model>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<Repair> Repairs => Set<Repair>();
        public DbSet<RepairType> RepairTypes => Set<RepairType>();
        public DbSet<VehicleListing> VehiclesListing => Set<VehicleListing>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Vin)
                    .HasMaxLength(17);

                entity.HasIndex(v => v.Vin)
                    .IsUnique();

                entity.Property(v => v.Year)
                    .IsRequired();

                entity.Property(v => v.Version)
                    .HasMaxLength(20);

                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Vehicles_Year",
                    "Year >= 1990"
                ));

                entity.HasOne(v => v.Model)
                    .WithMany()
                    .HasForeignKey(v => v.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(m => new { m.BrandId, m.Name })
                    .IsUnique();

                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(b => b.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasPrecision(8, 2);

                entity.Property(p => p.Date)
                    .IsRequired();

                entity.HasOne(p => p.Vehicle)
                    .WithOne()
                    .HasForeignKey<Purchase>(p => p.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Price)
                    .IsRequired()
                    .HasPrecision(7, 2);

                entity.HasOne(r => r.Vehicle)
                    .WithMany()
                    .HasForeignKey(r => r.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.RepairType)
                    .WithMany()
                    .HasForeignKey(r => r.RepairTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RepairType>(entity =>
            {
                entity.HasKey(rt => rt.Id);

                entity.Property(rt => rt.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(rt => rt.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<VehicleListing>(entity =>
            {
                entity.HasKey(vl => vl.Id);

                entity.HasIndex(vl => vl.AvailabilityDate);

                entity.Property(vl => vl.AvailabilityDate)
                    .IsRequired();

                entity.Property(vl => vl.AskingPrice)
                    .IsRequired()
                    .HasPrecision(8, 2);

                entity.Property(vl => vl.SalePrice)
                    .HasPrecision(8, 2);

                entity.HasOne(vl => vl.Vehicle)
                    .WithOne()
                    .HasForeignKey<VehicleListing>(vl => vl.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
