using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFood.Domain.Migrations
{
    public partial class AddStatusToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Restaurants");
        }
    }
}
