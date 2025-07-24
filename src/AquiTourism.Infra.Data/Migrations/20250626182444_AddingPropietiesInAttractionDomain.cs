using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquiTourism.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPropietiesInAttractionDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Aq.Attraction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeactivatedByUserId",
                table: "Aq.Attraction",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Aq.Attraction");

            migrationBuilder.DropColumn(
                name: "DeactivatedByUserId",
                table: "Aq.Attraction");
        }
    }
}
