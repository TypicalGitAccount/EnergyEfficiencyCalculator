using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class AverageCoolingSystemFactorsSeeder
    {
        public static async Task SeedTableAsync(IAverageCoolingSystemFactorsRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < typeof(CoolingSystemTypes).GetFields().Where(val => val.FieldType == typeof(string)).Count())
            {
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.ColdWater7To12, coolingExplicitUtilisationLevel = 0.87f, coolingUtilisationLevel = 1, distributionSubsystemUtilisationLevel = 0.9f });
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.ColdWater8To14, coolingExplicitUtilisationLevel = 0.9f, coolingUtilisationLevel = 1, distributionSubsystemUtilisationLevel = 0.9f });
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.ColdWater14To18, coolingExplicitUtilisationLevel = 1, coolingUtilisationLevel = 1, distributionSubsystemUtilisationLevel = 1 });
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.ColdWate16To18, coolingExplicitUtilisationLevel = 1, coolingUtilisationLevel = 1, distributionSubsystemUtilisationLevel = 1 });
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.ColdWater18To20, coolingExplicitUtilisationLevel = 1, coolingUtilisationLevel = 0.9f, distributionSubsystemUtilisationLevel = 1 });
                await repository.CreateAsync(
                    new AverageCoolingSystemFactors() { CoolingSystemType = CoolingSystemTypes.DirectEvaporation, coolingExplicitUtilisationLevel = 0.87f, coolingUtilisationLevel = 1, distributionSubsystemUtilisationLevel = 0.9f });
            }
        }
    }
}
