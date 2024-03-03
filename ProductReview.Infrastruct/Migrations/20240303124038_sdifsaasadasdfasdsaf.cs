using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductReview.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class sdifsaasadasdfasdsaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Permissions",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Roles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
