using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyAdvices;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyAdvices
{
    public class AdviceRepository : BaseRepository<Advice>, IAdviceRepository
    {
        public AdviceRepository(RelationalContext context) : base(context) { }
    }
}
