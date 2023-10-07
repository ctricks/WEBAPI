﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBAPI.Helpers;

#nullable disable

namespace WEBAPI.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WEBAPI.Entities.BetColorConfigs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.HasKey("Id");

                    b.ToTable("BetColorConfigs");
                });

            modelBuilder.Entity("WEBAPI.Entities.BetOdd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BetColorId")
                        .HasColumnType("int");

                    b.Property<int>("FightMatchId")
                        .HasColumnType("int");

                    b.Property<double>("OddValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BetOdds");
                });

            modelBuilder.Entity("WEBAPI.Entities.BetUserReward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<double>("RewardAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BetUserRewards");
                });

            modelBuilder.Entity("WEBAPI.Entities.FightMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchNumber")
                        .HasColumnType("int");

                    b.Property<int?>("MatchResultConfigId")
                        .HasColumnType("int");

                    b.Property<int>("MatchResultId")
                        .HasColumnType("int");

                    b.Property<int>("MatchStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchResultConfigId");

                    b.ToTable("FightMatches");
                });

            modelBuilder.Entity("WEBAPI.Entities.FightMatchConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<int>("MatchCurrentNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchTotalNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FightMatchConfigs");
                });

            modelBuilder.Entity("WEBAPI.Entities.MatchResultConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MatchResultConfigs");
                });

            modelBuilder.Entity("WEBAPI.Entities.MatchStatusConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MatchStatusConfigs");
                });

            modelBuilder.Entity("WEBAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_ts");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_ts");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAdmins");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserBetTxn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BetAmount")
                        .HasColumnType("float");

                    b.Property<int>("BetColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BetDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BetUserRewardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<int>("FightMatchId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BetUserRewardId");

                    b.ToTable("UserBetTxns");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_ts");

                    b.Property<int?>("UserBetTxnId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double?>("available_balance")
                        .HasColumnType("float");

                    b.Property<double?>("total_balance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserBetTxnId");

                    b.HasIndex("UserId");

                    b.ToTable("UserWallet");
                });

            modelBuilder.Entity("WEBAPI.Entities.WalletTxn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_ts");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserIDRef")
                        .HasColumnType("int");

                    b.Property<int?>("UserWalletId")
                        .HasColumnType("int");

                    b.Property<double>("account_bal")
                        .HasColumnType("float");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserWalletId");

                    b.ToTable("WalletTxns");
                });

            modelBuilder.Entity("WEBAPI.Entities.FightMatch", b =>
                {
                    b.HasOne("WEBAPI.Entities.MatchResultConfig", null)
                        .WithMany("FightMatches")
                        .HasForeignKey("MatchResultConfigId");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserBetTxn", b =>
                {
                    b.HasOne("WEBAPI.Entities.BetUserReward", null)
                        .WithMany("UBetTxn")
                        .HasForeignKey("BetUserRewardId");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserWallet", b =>
                {
                    b.HasOne("WEBAPI.Entities.UserBetTxn", null)
                        .WithMany("UWallet")
                        .HasForeignKey("UserBetTxnId");

                    b.HasOne("WEBAPI.Entities.User", null)
                        .WithMany("UWallet")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WEBAPI.Entities.WalletTxn", b =>
                {
                    b.HasOne("WEBAPI.Entities.UserWallet", null)
                        .WithMany("WalletTrans")
                        .HasForeignKey("UserWalletId");
                });

            modelBuilder.Entity("WEBAPI.Entities.BetUserReward", b =>
                {
                    b.Navigation("UBetTxn");
                });

            modelBuilder.Entity("WEBAPI.Entities.MatchResultConfig", b =>
                {
                    b.Navigation("FightMatches");
                });

            modelBuilder.Entity("WEBAPI.Entities.User", b =>
                {
                    b.Navigation("UWallet");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserBetTxn", b =>
                {
                    b.Navigation("UWallet");
                });

            modelBuilder.Entity("WEBAPI.Entities.UserWallet", b =>
                {
                    b.Navigation("WalletTrans");
                });
#pragma warning restore 612, 618
        }
    }
}
