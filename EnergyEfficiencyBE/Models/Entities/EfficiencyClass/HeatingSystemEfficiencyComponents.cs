using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class HeatingSystemEfficiencyComponents : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public TemperatureComponents TemperatureComponentType { get; set; }
        public TemperatureRegulationOptions RegulationOptions { get; set; } = TemperatureRegulationOptions.None;
        public TemperatureDifferenceOptions TemperaturDifference { get; set; } = TemperatureDifferenceOptions.None;
        public OuterEnclosureHeatLoss HeatLoss { get; set; } = OuterEnclosureHeatLoss.None;
        public decimal VerticalTemperatureProfileComponentFactor { get; set; } = 0;
        public decimal TemperatureRegulationComponentFactor { get; set; } = 0;
        public decimal ExteriorEnclosureHeatLossComponentFactor { get; set; } = 0;
    }
}
