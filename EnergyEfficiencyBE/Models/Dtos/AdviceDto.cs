using System.ComponentModel.DataAnnotations;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Dtos
{
    public class AdviceDto : BaseDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string RecommendationText { get; set; }

        [Required]
        public decimal MinPrice { get; set; }

        [Required]
        public decimal MaxPrice { get; set; }

        [Required]
        public BuildingType BuildingType { get; set; }
    }
}
