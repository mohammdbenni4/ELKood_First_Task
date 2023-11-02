using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBrunchIdToProductionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionLogs_Companies_CompanyId",
                table: "ProductionLogs");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ProductionLogs",
                newName: "BrunchId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionLogs_CompanyId",
                table: "ProductionLogs",
                newName: "IX_ProductionLogs_BrunchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionLogs_Brunches_BrunchId",
                table: "ProductionLogs",
                column: "BrunchId",
                principalTable: "Brunches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionLogs_Brunches_BrunchId",
                table: "ProductionLogs");

            migrationBuilder.RenameColumn(
                name: "BrunchId",
                table: "ProductionLogs",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionLogs_BrunchId",
                table: "ProductionLogs",
                newName: "IX_ProductionLogs_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionLogs_Companies_CompanyId",
                table: "ProductionLogs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
