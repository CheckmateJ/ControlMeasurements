using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlMeasurements.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amounts");
        }
    }
}
