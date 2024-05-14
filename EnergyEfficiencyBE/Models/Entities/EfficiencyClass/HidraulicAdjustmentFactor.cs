namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class HidraulicAdjustmentFactor : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SystemType { get; set; }
        public string SystemDescription { get; set; }
        public decimal FactorValue { get; set; }
    }
}
