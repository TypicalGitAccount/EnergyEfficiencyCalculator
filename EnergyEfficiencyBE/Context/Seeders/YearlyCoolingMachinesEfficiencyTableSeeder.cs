using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class YearlyCoolingMachinesEfficiencyTableSeeder
    {
        public static async Task SeedTableAsync(IYearlyCoolingMachinesEfficiencyRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < typeof(CoolingMachineTypes).GetFields().Where(val => val.FieldType == typeof(string)).Count())
            {
                await repository.CreateAsync(new YearlyCoolingMachinesEfficiency() { CoolingMachineType = CoolingMachineTypes.CompressorAirBased, Efficiency = 2.25f });
                await repository.CreateAsync(new YearlyCoolingMachinesEfficiency() { CoolingMachineType = CoolingMachineTypes.CompressorSoilBaased, Efficiency = 5 });
                await repository.CreateAsync(new YearlyCoolingMachinesEfficiency() { CoolingMachineType = CoolingMachineTypes.Absorbal, Efficiency = 1 });
                await repository.CreateAsync(new YearlyCoolingMachinesEfficiency() { CoolingMachineType = CoolingMachineTypes.DirectCooling, Efficiency = 12 });
            }
        }
    }
}
