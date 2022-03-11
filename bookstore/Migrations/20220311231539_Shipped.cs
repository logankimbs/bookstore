using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstore.Migrations
{
    public partial class Shipped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BookShipped",
                table: "Donations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookShipped",
                table: "Donations");
        }
    }
}
