using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScannerStockSystem.Persistence.Data.Scripts
{
    /// <inheritdoc />
    public partial class RemovedForeignKeYAndApplyNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ContactPersons");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ContactPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId",
                unique: true);
        }
    }
}
