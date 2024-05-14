namespace EnergyEfficiencyBE.Models.EfficiencyClass
{
    public class CoolingEnergyConsumptionModel
    {
        public decimal ConditionedAreaOrVolume;
        public string CoolingSystemType;
        public string CoolingMachineType;
        public decimal YearlyCoolingEnergy;
        public string RegulationSystemEfficiencyClass;
        public float electicityGenerationEfficiency { get; set; }
        public float heatGenerationEfficiency { get; set; }
    }
}
