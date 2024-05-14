using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices
{
    public class Advice : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title{ get; set; }

        public string RecommendationText { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public BuildingType BuildingType { get; set; }
    }
}
