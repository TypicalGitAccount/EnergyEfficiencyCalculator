using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class HidraulicAdjustmentFactorTableSeeder
    {
        public static async Task SeedTableAsync(IHidraulicAdjustmentFactorRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < 9)
            {
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.TwoPiped.Value,
                    SystemDescription = HidraulicSystemTypes.TwoPiped.SystemDescriptions.NotConfigured,
                    FactorValue = 1.03m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.TwoPiped.Value,
                    SystemDescription = HidraulicSystemTypes.TwoPiped.SystemDescriptions.ConfiguredWithMoreThan8Heaters,
                    FactorValue = 1.01m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.TwoPiped.Value,
                    SystemDescription = HidraulicSystemTypes.TwoPiped.SystemDescriptions.ConfiguredWith8OrLessHeaters,
                    FactorValue = 1m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.TwoPiped.Value,
                    SystemDescription = HidraulicSystemTypes.TwoPiped.SystemDescriptions.ConfiguredWithAutoPressureRegulation,
                    FactorValue = 0.98m
                });

                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.OnePipedConstantMode.Value,
                    SystemDescription = HidraulicSystemTypes.OnePipedConstantMode.SystemDescriptions.NotConfiguredNoBalancingArmoring,
                    FactorValue = 1.09m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.OnePipedConstantMode.Value,
                    SystemDescription = HidraulicSystemTypes.OnePipedConstantMode.SystemDescriptions.ConfiguredWithManualArmoring,
                    FactorValue = 1.07m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.OnePipedConstantMode.Value,
                    SystemDescription = HidraulicSystemTypes.OnePipedConstantMode.SystemDescriptions.ConfiguredWitAutoRegulators,
                    FactorValue = 1.05m
                });

                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.OnePipedVariabletMode.Value,
                    SystemDescription = HidraulicSystemTypes.OnePipedVariabletMode.SystemDescriptions.Configured,
                    FactorValue = 1.01m
                });
                await repository.CreateAsync(new HidraulicAdjustmentFactor()
                {
                    SystemType = HidraulicSystemTypes.OnePipedVariabletMode.Value,
                    SystemDescription = HidraulicSystemTypes.OnePipedVariabletMode.SystemDescriptions.NotConfigured,
                    FactorValue = 1
                });
            }
        }
    }
}
