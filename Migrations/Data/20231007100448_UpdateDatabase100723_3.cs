using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UpdateDatabase100723_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserBetTxnId",
                table: "UserWallet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWallet_UserBetTxnId",
                table: "UserWallet",
                column: "UserBetTxnId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWallet_UserBetTxns_UserBetTxnId",
                table: "UserWallet",
                column: "UserBetTxnId",
                principalTable: "UserBetTxns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWallet_UserBetTxns_UserBetTxnId",
                table: "UserWallet");

            migrationBuilder.DropIndex(
                name: "IX_UserWallet_UserBetTxnId",
                table: "UserWallet");

            migrationBuilder.DropColumn(
                name: "UserBetTxnId",
                table: "UserWallet");
        }
    }
}
