using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifySomeProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurentAmountOfProduct",
                table: "Brunches");

            migrationBuilder.AddColumn<string>(
                name: "DistributionLogId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DistributionLogId",
                table: "Transactions",
                column: "DistributionLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions",
                column: "DistributionLogId",
                principalTable: "DistributionLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DistributionLogId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DistributionLogId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CurentAmountOfProduct",
                table: "Brunches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
