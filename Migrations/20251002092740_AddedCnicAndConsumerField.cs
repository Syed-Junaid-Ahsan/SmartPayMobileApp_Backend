using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPayMobileApp_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedCnicAndConsumerField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cnicNumber",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "consumerName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_consumerName",
                table: "Users",
                column: "consumerName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_consumerName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "cnicNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "consumerName",
                table: "Users");
        }
    }
}
