using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class HidraulicAdjustmentFactorRepository : BaseRepository<HidraulicAdjustmentFactor>, IHidraulicAdjustmentFactorRepository
    {
        public HidraulicAdjustmentFactorRepository(RelationalContext context) : base(context) { }
    }
}
