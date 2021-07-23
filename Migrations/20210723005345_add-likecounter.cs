using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterCloneAPI.Migrations
{
    public partial class addlikecounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCounter",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCounter",
                table: "Tweets");
        }
    }
}
