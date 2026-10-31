using ExpressVoiture.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext(options)
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
            // Considération de la base Identity
            base.OnModelCreating(modelBuilder);

            // Configuration des entités
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
                    .WithMany(v => v.Repairs)
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

            // Seed des données (inventaire client)

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Mazda" },
                new Brand { Id = 2, Name = "Jeep" },
                new Brand { Id = 3, Name = "Renault" },
                new Brand { Id = 4, Name = "Ford" },
                new Brand { Id = 5, Name = "Honda" },
                new Brand { Id = 6, Name = "Volkswagen" }
            );

            // Seed Models
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Name = "Miata", BrandId = 1 },
                new Model { Id = 2, Name = "Liberty", BrandId = 2 },
                new Model { Id = 3, Name = "Scénic", BrandId = 3 },
                new Model { Id = 4, Name = "Explorer", BrandId = 4 },
                new Model { Id = 5, Name = "Civic", BrandId = 5 },
                new Model { Id = 6, Name = "GTI", BrandId = 6 },
                new Model { Id = 7, Name = "Edge", BrandId = 4 }
            );

            // Seed RepairTypes
            modelBuilder.Entity<RepairType>().HasData(
                new RepairType { Id = 1, Name = "Restauration complète" },
                new RepairType { Id = 2, Name = "Roulements des roues avant" },
                new RepairType { Id = 3, Name = "Radiateur" },
                new RepairType { Id = 4, Name = "Freins" },
                new RepairType { Id = 5, Name = "Pneus" },
                new RepairType { Id = 6, Name = "Climatisation" }
            );

            // Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Vin = null, Year = 2019, Version = "LE", ModelId = 1 },
                new Vehicle { Id = 3, Vin = null, Year = 2007, Version = "TCe", ModelId = 3 },
                new Vehicle { Id = 2, Vin = null, Year = 2007, Version = "Sport", ModelId = 2 },
                new Vehicle { Id = 4, Vin = null, Year = 2017, Version = "XLT", ModelId = 4 },
                new Vehicle { Id = 5, Vin = null, Year = 2008, Version = "LX", ModelId = 5 },
                new Vehicle { Id = 6, Vin = null, Year = 2016, Version = "S", ModelId = 6 },
                new Vehicle { Id = 7, Vin = null, Year = 2013, Version = "SEL", ModelId = 7 }
            );

            // Seed Purchases
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, Price = 1_800.00M, Date = new DateOnly(2022, 1, 7), VehicleId = 1 },
                new Purchase { Id = 2, Price = 4_500.00M, Date = new DateOnly(2022, 4, 2), VehicleId = 2 },
                new Purchase { Id = 3, Price = 1_800.00M, Date = new DateOnly(2022, 4, 4), VehicleId = 3 },
                new Purchase { Id = 4, Price = 24_350.00M, Date = new DateOnly(2022, 4, 5), VehicleId = 4 },
                new Purchase { Id = 5, Price = 4_000.00M, Date = new DateOnly(2022, 4, 6), VehicleId = 5 },
                new Purchase { Id = 6, Price = 15_250.00M, Date = new DateOnly(2022, 4, 6), VehicleId = 6 },
                new Purchase { Id = 7, Price = 10_990.00M, Date = new DateOnly(2022, 4, 7), VehicleId = 7 }
            );

            // Seed Repairs
            modelBuilder.Entity<Repair>().HasData(
                new Repair { Id = 1, Price = 7_600.00M, VehicleId = 1, RepairTypeId = 1 },
                new Repair { Id = 2, Price = 350.00M, VehicleId = 2, RepairTypeId = 2 },
                new Repair { Id = 3, Price = 690.00M, VehicleId = 3, RepairTypeId = 3 },
                new Repair { Id = 4, Price = 0.00M, VehicleId = 3, RepairTypeId = 4 },
                new Repair { Id = 5, Price = 1_100.00M, VehicleId = 4, RepairTypeId = 5 },
                new Repair { Id = 6, Price = 0.00M, VehicleId = 4, RepairTypeId = 4 },
                new Repair { Id = 7, Price = 475.00M, VehicleId = 5, RepairTypeId = 6 },
                new Repair { Id = 8, Price = 0.00M, VehicleId = 5, RepairTypeId = 4 },
                new Repair { Id = 9, Price = 440.00M, VehicleId = 6, RepairTypeId = 5 },
                new Repair { Id = 10, Price = 950.00M, VehicleId = 7, RepairTypeId = 5 },
                new Repair { Id = 11, Price = 0.00M, VehicleId = 7, RepairTypeId = 4 },
                new Repair { Id = 12, Price = 0.00M, VehicleId = 7, RepairTypeId = 6 }
            );

            // Seed VehicleListings
            modelBuilder.Entity<VehicleListing>().HasData(
                new VehicleListing { Id = 1, AvailabilityDate = new DateOnly(2022, 4, 7), AskingPrice = 9_900.00M, SaleDate = new DateOnly(2022, 4 ,8), VehicleId = 1 },
                new VehicleListing { Id = 2, AvailabilityDate = new DateOnly(2022, 4, 7), AskingPrice = 5_350.00M, SaleDate = new DateOnly(2022, 4, 9), VehicleId = 2 },
                new VehicleListing { Id = 3, AvailabilityDate = new DateOnly(2022, 4, 8), AskingPrice = 2_990.00M, VehicleId = 3 },
                new VehicleListing { Id = 4, AvailabilityDate = new DateOnly(2022, 4, 9), AskingPrice = 25_950.00M, VehicleId = 4 },
                new VehicleListing { Id = 5, AvailabilityDate = new DateOnly(2022, 4, 9), AskingPrice = 4_975.00M, SaleDate = new DateOnly(2022, 4, 9), VehicleId = 5 },
                new VehicleListing { Id = 6, AvailabilityDate = new DateOnly(2022, 4, 10), AskingPrice = 16_190.00M, SaleDate = new DateOnly(2022, 4, 12), VehicleId = 6 },
                new VehicleListing { Id = 7, AvailabilityDate = new DateOnly(2022, 4, 11), AskingPrice = 12_440.00M, SaleDate = new DateOnly(2022, 4, 12), VehicleId = 7 }
            );

        }
    }
}
