using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class PeakEnergyConsumptionTableSeeder
    {
        public static async Task SeedTableAsync(IPeakEnergyConsumptionRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < 24)
            {
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.First, StoriesMin = 1, StoriesMax = 3, Formula = "120" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.First, StoriesMin = 4, StoriesMax = 9, Formula = "85" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.First, StoriesMin = 10, StoriesMax = 16, Formula = "75" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.First, StoriesMin = 17, StoriesMax = int.MaxValue, Formula = "70" });

                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.Second, StoriesMin = 1, StoriesMax = 3, Formula = "110" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.Second, StoriesMin = 4, StoriesMax = 9, Formula = "75" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.Second, StoriesMin = 10, StoriesMax = 16, Formula = "70" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Private, TemperatureZone = TemperatureZone.Second, StoriesMin = 17, StoriesMax = int.MaxValue, Formula = "65" });

                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.First, StoriesMin = 1, StoriesMax = 3, Formula = "38 * [factor] + 15" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.First, StoriesMin = 4, StoriesMax = 9, Formula = "30" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.First, StoriesMin = 10, StoriesMax = int.MaxValue, Formula = "25" });

                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.Second, StoriesMin = 1, StoriesMax = 3, Formula = "34 * [factor] + 13" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.Second, StoriesMin = 4, StoriesMax = 9, Formula = "25" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Common, TemperatureZone = TemperatureZone.Second, StoriesMin = 10, StoriesMax = int.MaxValue, Formula = "20" });

                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Hotel, TemperatureZone = TemperatureZone.First, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "57 * [factor] + 60" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Educational, TemperatureZone = TemperatureZone.First, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "55 * [factor] + 24" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Preschool, TemperatureZone = TemperatureZone.First, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "32" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Healthcare, TemperatureZone = TemperatureZone.First, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "30" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Trading, TemperatureZone = TemperatureZone.First, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "33 * [factor] + 17" });

                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Hotel, TemperatureZone = TemperatureZone.Second, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "50 * [factor] + 55" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Educational, TemperatureZone = TemperatureZone.Second, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "52 * [factor] + 23" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Preschool, TemperatureZone = TemperatureZone.Second, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "28" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Healthcare, TemperatureZone = TemperatureZone.Second, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "26" });
                await repository.CreateAsync(new PeakEnergyConsumption() { BuildingType = BuildingType.Trading, TemperatureZone = TemperatureZone.Second, StoriesMin = 0, StoriesMax = int.MaxValue, Formula = "26 * [factor] + 15" });
            }
        }
    }
}
