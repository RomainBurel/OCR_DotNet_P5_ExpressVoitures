using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCR_DotNet_P5_ExpressVoitures.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RepairDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfRepair = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairCost = table.Column<double>(type: "float", nullable: false),
                    NoMoreAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAvailabilityForSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
