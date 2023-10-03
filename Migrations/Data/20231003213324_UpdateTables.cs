using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<int>(
                name: "BetColorId",
                table: "UserBetTxns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BetUserRewardId",
                table: "UserBetTxns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightMatchId",
                table: "UserBetTxns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BetColorId",
                table: "BetOdds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FightMatchId",
                table: "BetOdds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdmins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_BetUserRewardId",
                table: "UserBetTxns",
                column: "BetUserRewardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_FightMatchId",
                table: "UserBetTxns",
                column: "FightMatchId");

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
                name: "FK_UserBetTxns_BetUserRewards_BetUserRewardId",
                table: "UserBetTxns",
                column: "BetUserRewardId",
                principalTable: "BetUserRewards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBetTxns_FightMatches_FightMatchId",
                table: "UserBetTxns",
                column: "FightMatchId",
                principalTable: "FightMatches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetOdds_FightMatches_FightMatchId",
                table: "BetOdds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBetTxns_BetUserRewards_BetUserRewardId",
                table: "UserBetTxns");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBetTxns_FightMatches_FightMatchId",
                table: "UserBetTxns");

            migrationBuilder.DropTable(
                name: "UserAdmins");

            migrationBuilder.DropIndex(
                name: "IX_UserBetTxns_BetUserRewardId",
                table: "UserBetTxns");

            migrationBuilder.DropIndex(
                name: "IX_UserBetTxns_FightMatchId",
                table: "UserBetTxns");

            migrationBuilder.DropIndex(
                name: "IX_BetOdds_FightMatchId",
                table: "BetOdds");

            migrationBuilder.DropColumn(
                name: "BetColorId",
                table: "UserBetTxns");

            migrationBuilder.DropColumn(
                name: "BetUserRewardId",
                table: "UserBetTxns");

            migrationBuilder.DropColumn(
                name: "FightMatchId",
                table: "UserBetTxns");

            migrationBuilder.DropColumn(
                name: "BetColorId",
                table: "BetOdds");

            migrationBuilder.DropColumn(
                name: "FightMatchId",
                table: "BetOdds");
                       
        }
    }
}
