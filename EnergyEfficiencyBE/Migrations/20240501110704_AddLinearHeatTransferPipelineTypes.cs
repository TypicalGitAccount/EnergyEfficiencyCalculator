using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    /// <inheritdoc />
    public partial class AddLinearHeatTransferPipelineTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PipelineType",
                table: "LinearHeatTransferFactorTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BuildingSize",
                table: "LinearHeatTransferFactorTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsulatedDate",
                table: "LinearHeatTransferFactorTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OuterWallsPipeline",
                table: "LinearHeatTransferFactorTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PipelineSection",
                table: "LinearHeatTransferFactorTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingSize",
                table: "LinearHeatTransferFactorTable");

            migrationBuilder.DropColumn(
                name: "InsulatedDate",
                table: "LinearHeatTransferFactorTable");

            migrationBuilder.DropColumn(
                name: "OuterWallsPipeline",
                table: "LinearHeatTransferFactorTable");

            migrationBuilder.DropColumn(
                name: "PipelineSection",
                table: "LinearHeatTransferFactorTable");

            migrationBuilder.AlterColumn<string>(
                name: "PipelineType",
                table: "LinearHeatTransferFactorTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
