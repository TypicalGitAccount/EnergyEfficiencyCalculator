using EnergyEfficiencyBE.Models.Entities.Auth;
using EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EnergyEfficiencyBE.Context
{
    public class RelationalContext : DbContext
    {
        public RelationalContext(DbContextOptions<RelationalContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PeakEnergyConsumption> PeakEnergyConsumptionTable{ get; set; }
        public DbSet<YearlyCoolingMachinesEfficiency> YearlyCoolingMachinesEfficiencyTable { get; set; }
        public DbSet<AverageCoolingSystemFactors> AverageCoolingSystemFactorsTable { get; set; }
        public DbSet<HidraulicAdjustmentFactor> HidraulicAdjustmentFactorsTable { get; set; }
        public DbSet<LinearHeatTransferFactor> LinearHeatTransferFactorTable { get; set; }
        public DbSet<HeatingSystemEfficiencyComponents> HeatingSystemEfficiencyComponentsTable { get; set; }
        public DbSet<SeasonalHeatGenerationEfficiencyFactors> SeasonalHeatGenerationEfficiencyFactorsTable { get; set; }
        public DbSet<Advice> Recommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ConfigureUser(modelBuilder);
            ConfigurePeakEnergyConsumption(modelBuilder);
            ConfigureYearlyCoolingMachinesEfficiencyTable(modelBuilder);
            ConfigureAverageCoolingSystemFactorsTable(modelBuilder);
            ConfigureHidraulicAdjustmentFactorTable(modelBuilder);
            ConfigureHeatingEfficiencyComponentsTable(modelBuilder);
            ConfigureSeasonalHeatGenerationEfficiencyTable(modelBuilder);
            ConfigureAdvices(modelBuilder);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdentityId).IsRequired();

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);
                entity.Property(e => e.Telegram).HasMaxLength(255);
            });
        }

        private void ConfigurePeakEnergyConsumption(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeakEnergyConsumption>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.BuildingType).IsRequired();

                entity.Property(e => e.StoriesMin).IsRequired();

                entity.Property(e => e.StoriesMax);

                entity.Property(e => e.TemperatureZone).IsRequired();

                entity.Property(e => e.Formula).IsRequired();
            });
        }

        private void ConfigureYearlyCoolingMachinesEfficiencyTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YearlyCoolingMachinesEfficiency>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CoolingMachineType).IsRequired();

                entity.Property(e => e.Efficiency).IsRequired();
            });
        }

        private void ConfigureAverageCoolingSystemFactorsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AverageCoolingSystemFactors>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CoolingSystemType).IsRequired();

                entity.Property(e => e.distributionSubsystemUtilisationLevel).IsRequired();

                entity.Property(e => e.coolingUtilisationLevel).IsRequired();

                entity.Property(e => e.coolingExplicitUtilisationLevel).IsRequired();
            });
        }

        private void ConfigureHidraulicAdjustmentFactorTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HidraulicAdjustmentFactor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SystemType).IsRequired();

                entity.Property(e => e.SystemDescription).IsRequired();

                entity.Property(e => e.FactorValue).IsRequired().HasColumnType("DECIMAL");
            });
        }

        private void ConfigureHeatingEfficiencyComponentsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeatingSystemEfficiencyComponents>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TemperatureComponentType).IsRequired();

                entity.Property(e => e.RegulationOptions).IsRequired();

                entity.Property(e => e.TemperaturDifference).IsRequired();

                entity.Property(e => e.HeatLoss).IsRequired();

                entity.Property(e => e.TemperatureRegulationComponentFactor).IsRequired().HasColumnType("DECIMAL");

                entity.Property(e => e.VerticalTemperatureProfileComponentFactor).IsRequired().HasColumnType("DECIMAL");

                entity.Property(e => e.ExteriorEnclosureHeatLossComponentFactor).IsRequired().HasColumnType("DECIMAL");
            });
        }

        private void ConfigureSeasonalHeatGenerationEfficiencyTable (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeasonalHeatGenerationEfficiencyFactors>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.HeaterType).IsRequired();

                entity.Property(e => e.AnyDateFactor).HasDefaultValue(null);

                entity.Property(e => e.Before1994Factor).HasDefaultValue(null);

                entity.Property(e => e.From1994To2008Factor).HasDefaultValue(null);

                entity.Property(e => e.From2008Factor).HasDefaultValue(null);
            });
        }

        private void ConfigureAdvices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.RecommendationText).IsRequired();

                entity.Property(e => e.MinPrice).IsRequired();

                entity.Property(e => e.MaxPrice).IsRequired();

                entity.Property(e => e.BuildingType).IsRequired().HasMaxLength(255);
            });
        }
    }
}