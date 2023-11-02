using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCurAmountOfProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurentAmountOfProduct",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CurentAmountOfProduct",
                table: "Brunches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurentAmountOfProduct",
                table: "Brunches");

            migrationBuilder.AddColumn<int>(
                name: "CurentAmountOfProduct",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
