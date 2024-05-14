using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class HeatingEnergyFactorCriteriasAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemperatureComponentDescription",
                table: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.AlterColumn<int>(
                name: "TemperatureComponentType",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "HeatLoss",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegulationOptions",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperaturDifference",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeatLoss",
                table: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.DropColumn(
                name: "RegulationOptions",
                table: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.DropColumn(
                name: "TemperaturDifference",
                table: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.AlterColumn<string>(
                name: "TemperatureComponentType",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TemperatureComponentDescription",
                table: "HeatingSystemEfficiencyComponentsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
