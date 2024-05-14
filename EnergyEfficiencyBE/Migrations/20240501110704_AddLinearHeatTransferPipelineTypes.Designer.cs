﻿// <auto-generated />
using System;
using EnergyEfficiencyBE.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnergyEfficiencyBE.Migrations
{
    [DbContext(typeof(RelationalContext))]
    [Migration("20240501110704_AddLinearHeatTransferPipelineTypes")]
    partial class AddLinearHeatTransferPipelineTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telegram")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices.Advice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuildingType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("MaxPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RecommendationText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.AverageCoolingSystemFactors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoolingSystemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("coolingExplicitUtilisationLevel")
                        .HasColumnType("real");

                    b.Property<float>("coolingUtilisationLevel")
                        .HasColumnType("real");

                    b.Property<float>("distributionSubsystemUtilisationLevel")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("AverageCoolingSystemFactorsTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.HeatingSystemEfficiencyComponents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ExteriorEnclosureHeatLossComponentFactor")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("TemperatureComponentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemperatureComponentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TemperatureRegulationComponentFactor")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal>("VerticalTemperatureProfileComponentFactor")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.ToTable("HeatingSystemEfficiencyComponentsTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.HidraulicAdjustmentFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("FactorValue")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("SystemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HidraulicAdjustmentFactorsTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.LinearHeatTransferFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BuildingSize")
                        .HasColumnType("int");

                    b.Property<float>("FactorValue")
                        .HasColumnType("real");

                    b.Property<int>("InsulatedDate")
                        .HasColumnType("int");

                    b.Property<int>("OuterWallsPipeline")
                        .HasColumnType("int");

                    b.Property<int>("PipelineSection")
                        .HasColumnType("int");

                    b.Property<int>("PipelineType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LinearHeatTransferFactorTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.PeakEnergyConsumption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuildingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoriesMax")
                        .HasColumnType("int");

                    b.Property<int>("StoriesMin")
                        .HasColumnType("int");

                    b.Property<int>("TemperatureZone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PeakEnergyConsumptionTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.SeasonalHeatGenerationEfficiencyFactors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnyDateFactor")
                        .HasColumnType("int");

                    b.Property<int?>("Before1994Factor")
                        .HasColumnType("int");

                    b.Property<int?>("From1994To2008Factor")
                        .HasColumnType("int");

                    b.Property<int?>("From2008Factor")
                        .HasColumnType("int");

                    b.Property<string>("HeaterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SeasonalHeatGenerationEfficiencyFactorsTable");
                });

            modelBuilder.Entity("EnergyEfficiencyBE.Models.Entities.EfficiencyClass.YearlyCoolingMachinesEfficiency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoolingMachineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Efficiency")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("YearlyCoolingMachinesEfficiencyTable");
                });
#pragma warning restore 612, 618
        }
    }
}