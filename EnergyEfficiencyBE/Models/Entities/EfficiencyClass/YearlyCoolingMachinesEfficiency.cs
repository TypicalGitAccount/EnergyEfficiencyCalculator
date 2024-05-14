namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class YearlyCoolingMachinesEfficiency : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CoolingMachineType {  get; set; }
        public float Efficiency { get; set; }
    }
}
