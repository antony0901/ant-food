using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFood.Domain.Migrations
{
    public partial class ChangeTypeOfTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capicity",
                table: "Tables",
                newName: "Capacity");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Tables",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Tables",
                newName: "Capicity");

            migrationBuilder.AlterColumn<string>(
                name: "Order",
                table: "Tables",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
