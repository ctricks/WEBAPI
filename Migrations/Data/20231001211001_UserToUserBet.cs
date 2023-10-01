using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    public partial class UserToUserBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetOdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OddValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetOdds", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetColorConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BetOddId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetColorConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetColorConfigs_BetOdds_BetOddId",
                        column: x => x.BetOddId,
                        principalTable: "BetOdds",
                        principalColumn: "Id");
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
                name: "UserBetTxns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetAmount = table.Column<double>(type: "float", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBetTxns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBetTxns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserWallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    available_balance = table.Column<double>(type: "float", nullable: true),
                    total_balance = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    create_ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_ts = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWallet_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WalletTxns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    account_bal = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TokenID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IX_BetColorConfigs_BetOddId",
                table: "BetColorConfigs",
                column: "BetOddId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_MatchResultConfigId",
                table: "FightMatches",
                column: "MatchResultConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_FightMatches_MatchStatusConfigId",
                table: "FightMatches",
                column: "MatchStatusConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBetTxns_UserId",
                table: "UserBetTxns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallet_UserId",
                table: "UserWallet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTxns_UserWalletId",
                table: "WalletTxns",
                column: "UserWalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetColorConfigs");

            migrationBuilder.DropTable(
                name: "BetUserRewards");

            migrationBuilder.DropTable(
                name: "FightMatchConfigs");

            migrationBuilder.DropTable(
                name: "FightMatches");

            migrationBuilder.DropTable(
                name: "UserBetTxns");

            migrationBuilder.DropTable(
                name: "WalletTxns");

            migrationBuilder.DropTable(
                name: "BetOdds");

            migrationBuilder.DropTable(
                name: "MatchResultConfigs");

            migrationBuilder.DropTable(
                name: "MatchStatusConfigs");

            migrationBuilder.DropTable(
                name: "UserWallet");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
