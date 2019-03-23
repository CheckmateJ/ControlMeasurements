using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlMeasurements.Migrations
{
    public partial class SeedAmountData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amounts",
                columns: new[] { "Id", "MeasurementType", "Price" },
                values: new object[,]
                {
                    { new Guid("87243441-0c03-4de3-b110-40cafa170f66"), 0, 0.0 },
                    { new Guid("2695f178-3c7f-46e1-a41b-6ead72724af8"), 1, 0.0 },
                    { new Guid("0763c616-4099-48d9-be6c-7b332db79fe0"), 2, 0.0 },
                    { new Guid("4a9a1542-2bb1-4398-a8ea-b48ea8009733"), 3, 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amounts",
                keyColumn: "Id",
                keyValue: new Guid("0763c616-4099-48d9-be6c-7b332db79fe0"));

            migrationBuilder.DeleteData(
                table: "Amounts",
                keyColumn: "Id",
                keyValue: new Guid("2695f178-3c7f-46e1-a41b-6ead72724af8"));

            migrationBuilder.DeleteData(
                table: "Amounts",
                keyColumn: "Id",
                keyValue: new Guid("4a9a1542-2bb1-4398-a8ea-b48ea8009733"));

            migrationBuilder.DeleteData(
                table: "Amounts",
                keyColumn: "Id",
                keyValue: new Guid("87243441-0c03-4de3-b110-40cafa170f66"));
        }
    }
}
