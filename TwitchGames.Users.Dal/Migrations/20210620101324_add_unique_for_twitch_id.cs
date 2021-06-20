using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitchGames.Users.Dal.Migrations
{
    public partial class add_unique_for_twitch_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_TwitchId",
                table: "Users",
                column: "TwitchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TwitchId",
                table: "Users");
        }
    }
}
