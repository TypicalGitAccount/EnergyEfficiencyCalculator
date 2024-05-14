using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class AverageCoolingSubsystemFactorsRepository : BaseRepository<AverageCoolingSystemFactors>, IAverageCoolingSystemFactorsRepository
    {
        public AverageCoolingSubsystemFactorsRepository(RelationalContext context) : base(context) { }
    }
}
