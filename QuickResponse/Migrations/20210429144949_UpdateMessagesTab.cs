using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickResponse.Migrations
{
    public partial class UpdateMessagesTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
