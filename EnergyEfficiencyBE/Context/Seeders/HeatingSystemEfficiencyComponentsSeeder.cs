using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;
using HeatingSystemEfficiencyComponents = EnergyEfficiencyBE.Models.Entities.EfficiencyClass.HeatingSystemEfficiencyComponents;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class HeatingSystemEfficiencyComponentsSeeder
    {
        public static async Task SeedTableAsync(IHeatingSystemEfficiencyComponentsRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < 13)
            {
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.Absent,
                    TemperatureRegulationComponentFactor = 0.86m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.WhileAverageBuildingTemp,
                    TemperatureRegulationComponentFactor = 0.88m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.PRegulation2K,
                    TemperatureRegulationComponentFactor = 0.93m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.PRegulation1K,
                    TemperatureRegulationComponentFactor = 0.95m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.PIRegulation,
                    TemperatureRegulationComponentFactor = 0.97m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureRegulation,
                    RegulationOptions = TemperatureRegulationOptions.PiRegulationOptimised,
                    TemperatureRegulationComponentFactor = 0.99m,
                });

                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureDifference,
                    TemperaturDifference = TemperatureDifferenceOptions.K60,
                    VerticalTemperatureProfileComponentFactor = 0.88m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureDifference,
                    TemperaturDifference = TemperatureDifferenceOptions.K42,
                    VerticalTemperatureProfileComponentFactor = 0.93m
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.TemperatureDifference,
                    TemperaturDifference = TemperatureDifferenceOptions.K30,
                    VerticalTemperatureProfileComponentFactor = 0.95m
                });

                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.OuterEnclosureHeatLoss,
                    HeatLoss = OuterEnclosureHeatLoss.HeaterNearInnerWall,
                    VerticalTemperatureProfileComponentFactor = 0.87m,
                    ExteriorEnclosureHeatLossComponentFactor = 1
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.OuterEnclosureHeatLoss,
                    HeatLoss = OuterEnclosureHeatLoss.HeaterNearOuterWallNoRadiationalProtection,
                    VerticalTemperatureProfileComponentFactor = 0.83m,
                    ExteriorEnclosureHeatLossComponentFactor = 1
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.OuterEnclosureHeatLoss,
                    HeatLoss = OuterEnclosureHeatLoss.HeaterNearOuterWallWithRadiationalProtection,
                    VerticalTemperatureProfileComponentFactor = 0.88m,
                    ExteriorEnclosureHeatLossComponentFactor = 1
                });
                await repository.CreateAsync(new HeatingSystemEfficiencyComponents()
                {
                    TemperatureComponentType = TemperatureComponents.OuterEnclosureHeatLoss,
                    HeatLoss = OuterEnclosureHeatLoss.HeaterNearRegularOuterWall,
                    VerticalTemperatureProfileComponentFactor = 0.95m,
                    ExteriorEnclosureHeatLossComponentFactor = 1
                });
            }
        }
    }
}
