namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class AverageCoolingSystemFactors : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CoolingSystemType { get; set; }
        public float coolingUtilisationLevel { get; set; }
        public float coolingExplicitUtilisationLevel { get; set; }
        public float distributionSubsystemUtilisationLevel { get; set; }
    }
}
