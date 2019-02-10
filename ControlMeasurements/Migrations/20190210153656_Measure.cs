using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlMeasurements.Migrations
{
    public partial class Measure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementsCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlaceType = table.Column<int>(nullable: false),
                    MeasurementType = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
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
