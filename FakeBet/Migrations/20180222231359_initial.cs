﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FakeBet.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    MatchTime = table.Column<DateTime>(nullable: false),
                    PointsRatio = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TeamAName = table.Column<string>(nullable: true),
                    TeamAPoints = table.Column<int>(nullable: false),
                    TeamBName = table.Column<string>(nullable: true),
                    TeamBPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    NickName = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 64, nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Salt = table.Column<byte[]>(maxLength: 128, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.NickName);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<Guid>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: false),
                    MatchId1 = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    UserNickName = table.Column<string>(nullable: true),
                    UserPick = table.Column<int>(nullable: false),
                    UserPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Matches_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Users_UserNickName",
                        column: x => x.UserNickName,
                        principalTable: "Users",
                        principalColumn: "NickName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MatchId1",
                table: "Votes",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserNickName",
                table: "Votes",
                column: "UserNickName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}