using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitchGames.Ttny.Dal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Wood = table.Column<uint>(type: "INTEGER", nullable: false),
                    Food = table.Column<uint>(type: "INTEGER", nullable: false),
                    Defense = table.Column<uint>(type: "INTEGER", nullable: false),
                    NextAttackSize = table.Column<uint>(type: "INTEGER", nullable: false),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    ColorHex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TownEvents",
                columns: table => new
                {
                    TownEventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TownId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownEvents", x => x.TownEventId);
                    table.ForeignKey(
                        name: "FK_TownEvents_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TownUsers",
                columns: table => new
                {
                    TownId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false),
                    HaveAction = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownUsers", x => new { x.TownId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TownUsers_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TownEvents_TownId",
                table: "TownEvents",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_TownEvents_UserId",
                table: "TownEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TownUsers_UserId",
                table: "TownUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TownEvents");

            migrationBuilder.DropTable(
                name: "TownUsers");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
