using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UserWalletTrx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletTxns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    account_bal = table.Column<double>(type: "float", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserWalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTxns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTxns_UserWallet_UserWalletId",
                        column: x => x.UserWalletId,
                        principalTable: "UserWallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletTxns_UserWalletId",
                table: "WalletTxns",
                column: "UserWalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletTxns");
        }
    }
}
