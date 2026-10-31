using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpressVoiture.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateSchemaAndSeedInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vin = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.CheckConstraint("CK_Vehicles_Year", "Year >= 1990");
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    RepairTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairTypes_RepairTypeId",
                        column: x => x.RepairTypeId,
                        principalTable: "RepairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesListing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailabilityDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AskingPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    SaleDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesListing_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mazda" },
                    { 2, "Jeep" },
                    { 3, "Renault" },
                    { 4, "Ford" },
                    { 5, "Honda" },
                    { 6, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Restauration complète" },
                    { 2, "Roulements des roues avant" },
                    { 3, "Radiateur" },
                    { 4, "Freins" },
                    { 5, "Pneus" },
                    { 6, "Climatisation" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Miata" },
                    { 2, 2, "Liberty" },
                    { 3, 3, "Scénic" },
                    { 4, 4, "Explorer" },
                    { 5, 5, "Civic" },
                    { 6, 6, "GTI" },
                    { 7, 4, "Edge" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ModelId", "Version", "Vin", "Year" },
                values: new object[,]
                {
                    { 1, 1, "LE", null, 2019 },
                    { 2, 2, "Sport", null, 2007 },
                    { 3, 3, "TCe", null, 2007 },
                    { 4, 4, "XLT", null, 2017 },
                    { 5, 5, "LX", null, 2008 },
                    { 6, 6, "S", null, 2016 },
                    { 7, 7, "SEL", null, 2013 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Date", "Price", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 1, 7), 1800.00m, 1 },
                    { 2, new DateOnly(2022, 4, 2), 4500.00m, 2 },
                    { 3, new DateOnly(2022, 4, 4), 1800.00m, 3 },
                    { 4, new DateOnly(2022, 4, 5), 24350.00m, 4 },
                    { 5, new DateOnly(2022, 4, 6), 4000.00m, 5 },
                    { 6, new DateOnly(2022, 4, 6), 15250.00m, 6 },
                    { 7, new DateOnly(2022, 4, 7), 10990.00m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Price", "RepairTypeId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 7600.00m, 1, 1 },
                    { 2, 350.00m, 2, 2 },
                    { 3, 690.00m, 3, 3 },
                    { 4, 0.00m, 4, 3 },
                    { 5, 1100.00m, 5, 4 },
                    { 6, 0.00m, 4, 4 },
                    { 7, 475.00m, 6, 5 },
                    { 8, 0.00m, 4, 5 },
                    { 9, 440.00m, 5, 6 },
                    { 10, 950.00m, 5, 7 },
                    { 11, 0.00m, 4, 7 },
                    { 12, 0.00m, 6, 7 }
                });

            migrationBuilder.InsertData(
                table: "VehiclesListing",
                columns: new[] { "Id", "AskingPrice", "AvailabilityDate", "SaleDate", "SalePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, 9900.00m, new DateOnly(2022, 4, 7), new DateOnly(2022, 4, 8), null, 1 },
                    { 2, 5350.00m, new DateOnly(2022, 4, 7), new DateOnly(2022, 4, 9), null, 2 },
                    { 3, 2990.00m, new DateOnly(2022, 4, 8), null, null, 3 },
                    { 4, 25950.00m, new DateOnly(2022, 4, 9), null, null, 4 },
                    { 5, 4975.00m, new DateOnly(2022, 4, 9), new DateOnly(2022, 4, 9), null, 5 },
                    { 6, 16190.00m, new DateOnly(2022, 4, 10), new DateOnly(2022, 4, 12), null, 6 },
                    { 7, 12440.00m, new DateOnly(2022, 4, 11), new DateOnly(2022, 4, 12), null, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId_Name",
                table: "Models",
                columns: new[] { "BrandId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_VehicleId",
                table: "Purchases",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_VehicleId",
                table: "Repairs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_Name",
                table: "RepairTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles",
                column: "Vin",
                unique: true,
                filter: "[Vin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesListing_AvailabilityDate",
                table: "VehiclesListing",
                column: "AvailabilityDate");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesListing_VehicleId",
                table: "VehiclesListing",
                column: "VehicleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "VehiclesListing");

            migrationBuilder.DropTable(
                name: "RepairTypes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
