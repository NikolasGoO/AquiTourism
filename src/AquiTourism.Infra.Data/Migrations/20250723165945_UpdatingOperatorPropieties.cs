using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquiTourism.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingOperatorPropieties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Aq.Operator",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Aq.Operator");
        }
    }
}
