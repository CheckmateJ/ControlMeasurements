using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlMeasurements.Migrations
{
    public partial class ChangeMeasurementValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
