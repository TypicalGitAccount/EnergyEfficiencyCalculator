using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class decimalFieldsPrecisionChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
            name: "VerticalTemperatureProfileComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,4)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<decimal>(
            name: "TemperatureRegulationComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,4)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<decimal>(
            name: "ExteriorEnclosureHeatLossComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,4)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<decimal>(
            name: "FactorValue",
            table: "HidraulicAdjustmentFactorsTable",
            type: "DECIMAL(18,4)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
            name: "VerticalTemperatureProfileComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,0)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,4)");

            migrationBuilder.AlterColumn<decimal>(
            name: "TemperatureRegulationComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,0)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,4)");

            migrationBuilder.AlterColumn<decimal>(
            name: "ExteriorEnclosureHeatLossComponentFactor",
            table: "HeatingSystemEfficiencyComponentsTable",
            type: "DECIMAL(18,0)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18,4)");

            migrationBuilder.AlterColumn<decimal>(
            name: "FactorValue",
            table: "HidraulicAdjustmentFactorsTable",
            type: "DECIMAL(18,0)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "DECIMAL(18, 4)");
        }
    }
}
