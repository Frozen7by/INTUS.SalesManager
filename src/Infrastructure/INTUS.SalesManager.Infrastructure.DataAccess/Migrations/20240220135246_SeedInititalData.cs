using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTUS.SalesManager.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedInititalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1L, "NY" },
                    { 2L, "CA" }
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1L, "Window" },
                    { 2L, "Doors" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "DeletedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 1L, DateTime.UtcNow, null, null, "New York Building 1", 1L },
                    { 2L, DateTime.UtcNow, null, null, "California Hotel AJK", 2L }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "DeletedDate", "Name", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1L, DateTime.UtcNow, null, null, "A51", 1L, 4 },
                    { 2L, DateTime.UtcNow, null, null, "C Zone 5", 1L, 2 },
                    { 3L, DateTime.UtcNow, null, null, "GLB", 2L, 3 },
                    { 4L, DateTime.UtcNow, null, null, "OHF", 2L, 10 }
                });

            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "DeletedDate", "ElementTypeId", "Index", "Width", "Height", "WindowId" },
                values: new object[,]
                {
                    { 1L, DateTime.UtcNow, null, null, 2L, 1, 1200, 1850, 1L },
                    { 2L, DateTime.UtcNow, null, null, 1L, 2, 800, 1850, 1L },
                    { 3L, DateTime.UtcNow, null, null, 1L, 3, 700, 1850, 1L },
                    { 4L, DateTime.UtcNow, null, null, 1L, 1, 1500, 2000, 2L },
                    { 5L, DateTime.UtcNow, null, null, 2L, 1, 1400, 2200, 3L },
                    { 6L, DateTime.UtcNow, null, null, 1L, 2, 600, 2200, 3L },
                    { 7L, DateTime.UtcNow, null, null, 1L, 1, 1500, 2000, 4L },
                    { 8L, DateTime.UtcNow, null, null, 1L, 1, 1500, 2000, 4L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
