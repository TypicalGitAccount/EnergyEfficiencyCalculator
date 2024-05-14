using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class SeasonalHeatGenerationEfficiencyFactorSeeder
    {
        private static SeasonalHeatGenerationEfficiencyFactors _getFactors(SeasonalHeatGenerationDevices heater, int? any, int? before1994, int? to2008, int? from2008)
        {
            return new SeasonalHeatGenerationEfficiencyFactors()
            {
                HeaterType = heater,
                AnyDateFactor = any,
                Before1994Factor = before1994,
                From1994To2008Factor = to2008,
                From2008Factor = from2008
            };
        }

        public static async Task SeedTableAsync(ISeasonalHeatGenerationEfficiencyFactorRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < 15)
            {
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.CoalHeaterManual, null, 53, 55, 57));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.CeramicFurnance, null, 48, 52, 54));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.GasConvector, null, 63, 67, 71));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.GasHeaterWithSwich, null, 69, 70, 71));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.LiquidFuelModularBurner, null, 72, 76, 78));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.LiquidFuelLowTemperatur, null, 72, 75, 78));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.HeavyMazutSteamHeater, null, 67, 70, 72));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.LPGHeaterCompressor55C, 140, null, null, null));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.LPGHeaterCompressor35C, 160, null, null, null));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.ElectricTankless, 94, null, null, null));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.ElectricDirectHeating, 99, null, null, null));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.BiomassFurnance, null, 48, 52, 54));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.WoodBiomassHeaterGasified, null, 62, 66, 68));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.CentralisedConstantTemp, null, 50, 50, 50));
                await repository.CreateAsync(_getFactors(SeasonalHeatGenerationDevices.CentralisedHotWaterDistributionRestraintITPAccumulation, null, 95, 95, 96));
            }
        }
    }
}
