using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifySomePropVer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "DistributionLogId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions",
                column: "DistributionLogId",
                principalTable: "DistributionLogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "DistributionLogId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_DistributionLogs_DistributionLogId",
                table: "Transactions",
                column: "DistributionLogId",
                principalTable: "DistributionLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
