using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class YearlyCoolingMachinesEfficiencyRepository : BaseRepository<YearlyCoolingMachinesEfficiency>, IYearlyCoolingMachinesEfficiencyRepository
    {
        public YearlyCoolingMachinesEfficiencyRepository(RelationalContext context) : base(context) { }
    }
}
