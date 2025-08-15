using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFirstStage.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Ürün adı"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Ürün açıklaması"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ürün fiyatı"),
                    StockQuantity = table.Column<int>(type: "int", nullable: false, comment: "Stok miktarı"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Ürün resim URL'i"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Aktif mi?"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Silinmiş mi?"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Oluşturulma tarihi"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Güncellenme tarihi"),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Silinme tarihi")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsActive",
                table: "Products",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsActive_IsDeleted",
                table: "Products",
                columns: new[] { "IsActive", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDeleted",
                table: "Products",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
