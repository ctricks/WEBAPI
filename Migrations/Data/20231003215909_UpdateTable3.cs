using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UpdateTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIDRef",
                table: "WalletTxns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BetColorConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetColorConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetUserRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardAmount = table.Column<double>(type: "float", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetUserRewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FightMatchConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchCurrentNumber = table.Column<int>(type: "int", nullable: false),
                    MatchTotalNumber = table.Column<int>(type: "int", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightMatchConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchResultConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResultConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatusConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatusConfigs", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "FightMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchNumber = table.Column<int>(type: "int", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchResultConfigId = table.Column<int>(type: "int", nullable: true),
                    MatchStatusConfigId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightMatches_MatchResultConfigs_MatchResultConfigId",
                        column: x => x.MatchResultConfigId,
                        principalTable: "MatchResultConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FightMatches_MatchStatusConfigs_MatchStatusConfigId",
                        column: x => x.MatchStatusConfigId,
                        principalTable: "MatchStatusConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BetOdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetColorId = table.Column<int>(type: "int", nullable: false),
                    FightMatchId = table.Column<int>(type: "int", nullable: false),
                    OddValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetOdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetOdds_FightMatches_FightMatchId",
                        column: x => x.FightMatchId,
                        principalTable: "FightMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBetTxns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetAmount = table.Column<double>(type: "float", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BetColorId = table.Column<int>(type: "int", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BetUserRewardId = table.Column<int>(type: "int", nullable: true),
                    FightMatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBetTxns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBetTxns_BetUserRewards_BetUserRewardId",
                        column: x => x.BetUserRewardId,
                        principalTable: "BetUserRewards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBetTxns_FightMatches_FightMatchId",
                        column: x => x.FightMatchId,
                        principalTable: "FightMatches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetOdds_FightMatchId",
                table: "BetOdds",
                column: "FightMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_MatchResultConfigId",
                table: "FightMatches",
                column: "MatchResultConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_MatchStatusConfigId",
                table: "FightMatches",
                column: "MatchStatusConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_BetUserRewardId",
                table: "UserBetTxns",
                column: "BetUserRewardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_FightMatchId",
                table: "UserBetTxns",
                column: "FightMatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetColorConfigs");

            migrationBuilder.DropTable(
                name: "BetOdds");

            migrationBuilder.DropTable(
                name: "FightMatchConfigs");

            migrationBuilder.DropTable(
                name: "UserAdmins");

            migrationBuilder.DropTable(
                name: "UserBetTxns");

            migrationBuilder.DropTable(
                name: "BetUserRewards");

            migrationBuilder.DropTable(
                name: "FightMatches");

            migrationBuilder.DropTable(
                name: "MatchResultConfigs");

            migrationBuilder.DropTable(
                name: "MatchStatusConfigs");

            migrationBuilder.DropColumn(
                name: "UserIDRef",
                table: "WalletTxns");
        }
    }
}
