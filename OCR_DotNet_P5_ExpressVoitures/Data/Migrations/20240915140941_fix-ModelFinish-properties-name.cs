using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCR_DotNet_P5_ExpressVoitures.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixModelFinishpropertiesname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdBrand",
                table: "ModelFinishes",
                newName: "IdFinish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdFinish",
                table: "ModelFinishes",
                newName: "IdBrand");
        }
    }
}
