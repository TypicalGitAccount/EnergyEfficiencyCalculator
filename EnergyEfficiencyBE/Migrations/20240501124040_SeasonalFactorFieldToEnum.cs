using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class SeasonalFactorFieldToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HeaterType",
                table: "SeasonalHeatGenerationEfficiencyFactorsTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeaterType",
                table: "SeasonalHeatGenerationEfficiencyFactorsTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
