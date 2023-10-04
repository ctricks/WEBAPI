using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class ChangeTableDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetOdds_FightMatches_FightMatchId",
                table: "BetOdds");

            migrationBuilder.DropForeignKey(
                name: "FK_FightMatches_MatchStatusConfigs_MatchStatusConfigId",
                table: "FightMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBetTxns_FightMatches_FightMatchId",
                table: "UserBetTxns");

            migrationBuilder.DropIndex(
                name: "IX_UserBetTxns_FightMatchId",
                table: "UserBetTxns");

            migrationBuilder.DropIndex(
                name: "IX_FightMatches_MatchStatusConfigId",
                table: "FightMatches");

            migrationBuilder.DropIndex(
                name: "IX_BetOdds_FightMatchId",
                table: "BetOdds");

            migrationBuilder.DropColumn(
                name: "MatchStatusConfigId",
                table: "FightMatches");

            migrationBuilder.AlterColumn<int>(
                name: "FightMatchId",
                table: "UserBetTxns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBetTxns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchResultId",
                table: "FightMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchStatusId",
                table: "FightMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBetTxns");

            migrationBuilder.DropColumn(
                name: "MatchResultId",
                table: "FightMatches");

            migrationBuilder.DropColumn(
                name: "MatchStatusId",
                table: "FightMatches");

            migrationBuilder.AlterColumn<int>(
                name: "FightMatchId",
                table: "UserBetTxns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MatchStatusConfigId",
                table: "FightMatches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_FightMatchId",
                table: "UserBetTxns",
                column: "FightMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_MatchStatusConfigId",
                table: "FightMatches",
                column: "MatchStatusConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_BetOdds_FightMatchId",
                table: "BetOdds",
                column: "FightMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetOdds_FightMatches_FightMatchId",
                table: "BetOdds",
                column: "FightMatchId",
                principalTable: "FightMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightMatches_MatchStatusConfigs_MatchStatusConfigId",
                table: "FightMatches",
                column: "MatchStatusConfigId",
                principalTable: "MatchStatusConfigs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBetTxns_FightMatches_FightMatchId",
                table: "UserBetTxns",
                column: "FightMatchId",
                principalTable: "FightMatches",
                principalColumn: "Id");
        }
    }
}
