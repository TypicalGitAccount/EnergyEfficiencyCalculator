using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Dtos
{
    public class AdviceCriteriaDto
    {
        public decimal MinPrice { get; set; } = 0;

        public decimal MaxPrice { get; set; } = decimal.MaxValue;

        public BuildingType BuildingType { get; set; } = BuildingType.Any;
    }
}
