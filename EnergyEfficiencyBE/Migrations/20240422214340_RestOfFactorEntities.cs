using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class RestOfFactorEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AverageCoolingSystemFactorsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoolingSystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coolingUtilisationLevel = table.Column<float>(type: "real", nullable: false),
                    coolingExplicitUtilisationLevel = table.Column<float>(type: "real", nullable: false),
                    distributionSubsystemUtilisationLevel = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AverageCoolingSystemFactorsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatingSystemEfficiencyComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemperatureComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureComponentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerticalTemperatureProfileComponentFactor = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    TemperatureRegulationComponentFactor = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    ExteriorEnclosureHeatLossComponentFactor = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingSystemEfficiencyComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HidraulicAdjustmentFactorsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactorValue = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HidraulicAdjustmentFactorsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonalHeatGenerationEfficiencyFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeaterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnyDateFactor = table.Column<int>(type: "int", nullable: true),
                    Before1994Factor = table.Column<int>(type: "int", nullable: true),
                    From1994To2008Factor = table.Column<int>(type: "int", nullable: true),
                    From2008Factor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonalHeatGenerationEfficiencyFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearlyCoolingMachinesEfficiencyTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoolingMachineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efficiency = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyCoolingMachinesEfficiencyTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageCoolingSystemFactorsTable");

            migrationBuilder.DropTable(
                name: "HeatingSystemEfficiencyComponents");

            migrationBuilder.DropTable(
                name: "HidraulicAdjustmentFactorsTable");

            migrationBuilder.DropTable(
                name: "SeasonalHeatGenerationEfficiencyFactors");

            migrationBuilder.DropTable(
                name: "YearlyCoolingMachinesEfficiencyTable");
        }
    }
}
