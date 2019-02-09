using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlMeasurements.Migrations
{
    public partial class MeasurementCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementsCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Measurement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementsCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementsCategory");
        }
    }
}
