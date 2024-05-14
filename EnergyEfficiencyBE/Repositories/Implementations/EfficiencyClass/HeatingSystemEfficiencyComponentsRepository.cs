using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class HeatingSystemEfficiencyComponentsRepository : BaseRepository<HeatingSystemEfficiencyComponents>, IHeatingSystemEfficiencyComponentsRepository
    {
        public HeatingSystemEfficiencyComponentsRepository(RelationalContext context) : base(context) { }
    }
}
