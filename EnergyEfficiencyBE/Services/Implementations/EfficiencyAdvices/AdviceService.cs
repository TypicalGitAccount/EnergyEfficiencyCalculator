using AutoMapper;
using EnergyEfficiencyBE.Models.Dtos;
using EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyAdvices;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyAdvices;

namespace EnergyEfficiencyBE.Services.Implementations.EfficiencyAdvices
{
    public class AdviceService : BaseService<Advice, AdviceDto>, IAdviceService
    {
        public AdviceService(IAdviceRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
