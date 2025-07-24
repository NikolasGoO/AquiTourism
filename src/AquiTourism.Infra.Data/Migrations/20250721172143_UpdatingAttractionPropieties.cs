using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquiTourism.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingAttractionPropieties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivatedByUserId",
                table: "Aq.Attraction",
                newName: "UpdatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedByUserId",
                table: "Aq.Attraction",
                newName: "ActivatedByUserId");
        }
    }
}
