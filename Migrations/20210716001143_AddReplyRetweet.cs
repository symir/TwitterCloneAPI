using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterCloneAPI.Migrations
{
    public partial class AddReplyRetweet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RetweetId",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "RetweetId",
                table: "Tweets");
        }
    }
}
