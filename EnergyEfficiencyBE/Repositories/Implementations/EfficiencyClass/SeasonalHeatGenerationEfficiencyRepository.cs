using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class SeasonalHeatGenerationEfficiencyRepository : BaseRepository<SeasonalHeatGenerationEfficiencyFactors>, ISeasonalHeatGenerationEfficiencyFactorRepository
    {
        public SeasonalHeatGenerationEfficiencyRepository(RelationalContext context) : base(context) { }
    }
}
