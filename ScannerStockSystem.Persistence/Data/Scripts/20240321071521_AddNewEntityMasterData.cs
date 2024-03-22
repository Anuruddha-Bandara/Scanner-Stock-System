using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScannerStockSystem.Persistence.Data.Scripts
{
    /// <inheritdoc />
    public partial class AddNewEntityMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ScannerTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScannerTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SerialNo",
                table: "Scanners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanjePoNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ManufactureInvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureSalesOrderNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShipmentReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndCustomerPoNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeliveryNoteNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dispatched = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ScannerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterDatas_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDatas_Scanners_ScannerId",
                        column: x => x.ScannerId,
                        principalTable: "Scanners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterDatas_CustomerId",
                table: "MasterDatas",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDatas_ScannerId",
                table: "MasterDatas",
                column: "ScannerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterDatas");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Scanners");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ScannerTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScannerTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
