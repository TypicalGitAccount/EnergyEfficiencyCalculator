using static EnergyEfficiencyBE.Constants;
using System.ComponentModel.DataAnnotations;
using EnergyEfficiencyBE.Models.Validation;

namespace EnergyEfficiencyBE.Models.EfficiencyClass
{
    public class EfficiencyMeterInputModel
    {
        public decimal efficiencyValue { get; set; }
        [EnumDataType(typeof(TemperatureZone))]
        public TemperatureZone TempZone { get; set; }
        [Required(ErrorMessage = "Тип будівлі є обов'язковим полем!")]
        public BuildingType Building { get; set; }
        [NonZero("Поверховість")]
        public int Stories { get; set; }
    }
}
