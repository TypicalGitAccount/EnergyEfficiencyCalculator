using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass
{
    public class LinearHeatTransferFactorRepository : BaseRepository<LinearHeatTransferFactor>, ILinearHeatTransferFactorRepository
    {
        public LinearHeatTransferFactorRepository(RelationalContext context) : base(context)
        {
        }
    }
}
