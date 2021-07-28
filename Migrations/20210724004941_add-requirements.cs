using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterCloneAPI.Migrations
{
    public partial class addrequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tweets",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(280)",
                oldMaxLength: 280,
                oldNullable: true);
        }
    }
}
