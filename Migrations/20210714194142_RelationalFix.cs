using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterCloneAPI.Migrations
{
    public partial class RelationalFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tweets",
                newName: "TweetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TweetId",
                table: "Tweets",
                newName: "Id");
        }
    }
}
