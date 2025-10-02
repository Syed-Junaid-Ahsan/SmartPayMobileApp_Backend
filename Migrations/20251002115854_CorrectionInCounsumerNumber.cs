using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPayMobileApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionInCounsumerNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "consumerName",
                table: "Users",
                newName: "consumerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_consumerName",
                table: "Users",
                newName: "IX_Users_consumerNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "consumerNumber",
                table: "Users",
                newName: "consumerName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_consumerNumber",
                table: "Users",
                newName: "IX_Users_consumerName");
        }
    }
}
