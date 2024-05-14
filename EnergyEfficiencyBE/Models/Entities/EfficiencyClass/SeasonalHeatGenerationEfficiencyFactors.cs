using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class SeasonalHeatGenerationEfficiencyFactors : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public SeasonalHeatGenerationDevices HeaterType { get; set; }
        public int? AnyDateFactor { get; set; }
        public int? Before1994Factor { get; set; }
        public int? From1994To2008Factor { get; set; }
        public int? From2008Factor { get; set; }
    }
}
