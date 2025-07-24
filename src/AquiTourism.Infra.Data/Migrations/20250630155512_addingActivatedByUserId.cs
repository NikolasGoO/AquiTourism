using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquiTourism.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingActivatedByUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivatedByUserId",
                table: "Aq.Attraction",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivatedByUserId",
                table: "Aq.Attraction");
        }
    }
}
