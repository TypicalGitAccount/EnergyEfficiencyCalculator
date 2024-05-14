using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class PeakEnergyConsumptionRepository : BaseRepository<PeakEnergyConsumption>, IPeakEnergyConsumptionRepository
    {
        public PeakEnergyConsumptionRepository(RelationalContext context) : base(context) { }
    }
}
