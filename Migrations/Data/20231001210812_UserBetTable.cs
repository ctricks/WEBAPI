using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UserBetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetColorConfigs_UserBetTxns_UserBetTxnId",
                table: "BetColorConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_BetOdds_UserBetTxns_UserBetTxnId",
                table: "BetOdds");

            migrationBuilder.DropForeignKey(
                name: "FK_FightMatches_UserBetTxns_UserBetTxnId",
                table: "FightMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserBetTxns_UserBetTxnId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserBetTxnId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FightMatches_UserBetTxnId",
                table: "FightMatches");

            migrationBuilder.DropIndex(
                name: "IX_BetOdds_UserBetTxnId",
                table: "BetOdds");

            migrationBuilder.DropIndex(
                name: "IX_BetColorConfigs_UserBetTxnId",
                table: "BetColorConfigs");

            migrationBuilder.DropColumn(
                name: "UserBetTxnId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserBetTxnId",
                table: "FightMatches");

            migrationBuilder.DropColumn(
                name: "UserBetTxnId",
                table: "BetOdds");

            migrationBuilder.DropColumn(
                name: "UserBetTxnId",
                table: "BetColorConfigs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBetTxns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_UserId",
                table: "UserBetTxns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBetTxns_Users_UserId",
                table: "UserBetTxns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBetTxns_Users_UserId",
                table: "UserBetTxns");

            migrationBuilder.DropIndex(
                name: "IX_UserBetTxns_UserId",
                table: "UserBetTxns");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBetTxns");

            migrationBuilder.AddColumn<int>(
                name: "UserBetTxnId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBetTxnId",
                table: "FightMatches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBetTxnId",
                table: "BetOdds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBetTxnId",
                table: "BetColorConfigs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserBetTxnId",
                table: "Users",
                column: "UserBetTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_UserBetTxnId",
                table: "FightMatches",
                column: "UserBetTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_BetOdds_UserBetTxnId",
                table: "BetOdds",
                column: "UserBetTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_BetColorConfigs_UserBetTxnId",
                table: "BetColorConfigs",
                column: "UserBetTxnId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetColorConfigs_UserBetTxns_UserBetTxnId",
                table: "BetColorConfigs",
                column: "UserBetTxnId",
                principalTable: "UserBetTxns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BetOdds_UserBetTxns_UserBetTxnId",
                table: "BetOdds",
                column: "UserBetTxnId",
                principalTable: "UserBetTxns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FightMatches_UserBetTxns_UserBetTxnId",
                table: "FightMatches",
                column: "UserBetTxnId",
                principalTable: "UserBetTxns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserBetTxns_UserBetTxnId",
                table: "Users",
                column: "UserBetTxnId",
                principalTable: "UserBetTxns",
                principalColumn: "Id");
        }
    }
}
