using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_Users_UserId",
                table: "UserWallet");

            migrationBuilder.DropIndex(
                name: "IX_UserWallet_UserId",
                table: "UserWallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "UserWallet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallet_UserPhoneNumber",
                table: "UserWallet",
                column: "UserPhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_Users_UserPhoneNumber",
                table: "UserWallet",
                column: "UserPhoneNumber",
                principalTable: "Users",
                principalColumn: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_Users_UserPhoneNumber",
                table: "UserWallet");

            migrationBuilder.DropIndex(
                name: "IX_UserWallet_UserPhoneNumber",
                table: "UserWallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "UserWallet");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallet_UserId",
                table: "UserWallet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_Users_UserId",
                table: "UserWallet",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
