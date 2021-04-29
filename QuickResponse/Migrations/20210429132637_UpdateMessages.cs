using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickResponse.Migrations
{
    public partial class UpdateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "FromUserEmail",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUserEmail",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromUserEmail",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToUserEmail",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
