using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCR_DotNet_P5_ExpressVoitures.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedatamodelfinishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finishes",
                columns: table => new
                {
                    IdFinish = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishes", x => x.IdFinish);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finishes");
        }
    }
}
