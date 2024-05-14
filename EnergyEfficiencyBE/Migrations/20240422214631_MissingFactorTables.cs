using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class MissingFactorTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeasonalHeatGenerationEfficiencyFactors",
                table: "SeasonalHeatGenerationEfficiencyFactors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeatingSystemEfficiencyComponents",
                table: "HeatingSystemEfficiencyComponents");

            migrationBuilder.RenameTable(
                name: "SeasonalHeatGenerationEfficiencyFactors",
                newName: "SeasonalHeatGenerationEfficiencyFactorsTable");

            migrationBuilder.RenameTable(
                name: "HeatingSystemEfficiencyComponents",
                newName: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeasonalHeatGenerationEfficiencyFactorsTable",
                table: "SeasonalHeatGenerationEfficiencyFactorsTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeatingSystemEfficiencyComponentsTable",
                table: "HeatingSystemEfficiencyComponentsTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LinearHeatTransferFactorTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PipelineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactorValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinearHeatTransferFactorTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinearHeatTransferFactorTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeasonalHeatGenerationEfficiencyFactorsTable",
                table: "SeasonalHeatGenerationEfficiencyFactorsTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeatingSystemEfficiencyComponentsTable",
                table: "HeatingSystemEfficiencyComponentsTable");

            migrationBuilder.RenameTable(
                name: "SeasonalHeatGenerationEfficiencyFactorsTable",
                newName: "SeasonalHeatGenerationEfficiencyFactors");

            migrationBuilder.RenameTable(
                name: "HeatingSystemEfficiencyComponentsTable",
                newName: "HeatingSystemEfficiencyComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeasonalHeatGenerationEfficiencyFactors",
                table: "SeasonalHeatGenerationEfficiencyFactors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeatingSystemEfficiencyComponents",
                table: "HeatingSystemEfficiencyComponents",
                column: "Id");
        }
    }
}
