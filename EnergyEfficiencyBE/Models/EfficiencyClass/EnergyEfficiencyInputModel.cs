using EnergyEfficiencyBE.Models.Validation;
using System.ComponentModel.DataAnnotations;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.EfficiencyClass
{
    public class EnergyEfficiencyInputModel
    {
        [EnumDataType(typeof(TemperatureZone))]
        public TemperatureZone TempZone { get; set; }

        [EnumDataType(typeof(HeaterFactors))]
        public HeaterFactors HeaterFactorFieldName { get; set; }

        [Required(ErrorMessage = "Тип будівлі є обов'язковим полем!")]
        public BuildingType Building { get; set; }

        [Required(ErrorMessage = "Клас ефективності системи регуляції є обов'язковим полем!")]
        [SpecificValues<string>(
            new string[] { EnergyEfficiencyClass.a, EnergyEfficiencyClass.b,
            EnergyEfficiencyClass.c, EnergyEfficiencyClass.d,
                EnergyEfficiencyClass.e, EnergyEfficiencyClass.f, EnergyEfficiencyClass.g})]
        public string RegulationSystemEfficiencyClass { get; set; }

        [Required(ErrorMessage = "Вид охолоджувального пристрою є обов'язковим полем!")]
        [SpecificValues<string>(
            new string[] { CoolingMachineTypes.Absorbal, CoolingMachineTypes.DirectCooling,
            CoolingMachineTypes.CompressorSoilBaased, CoolingMachineTypes.CompressorAirBased})]
        public string CoolingMachineType { get; set; }

        [Required(ErrorMessage = "Вид охолоджувальної системи є обов'язковим полем!")]
        [SpecificValues<string>(
            new string[] { CoolingSystemTypes.ColdWater7To12, CoolingSystemTypes.ColdWater8To14, CoolingSystemTypes.ColdWater14To18,
            CoolingSystemTypes.ColdWate16To18, CoolingSystemTypes.ColdWater18To20, CoolingSystemTypes.DirectEvaporation})]
        public string CoolingSystemType { get; set; }

        public PipelineTypes PipelineType { get; set; }
        public PipelineSections[] PipelineSections { get; set; }
        public InsulatedOpenPipelines InsulatedDate { get; set; }
        public OuterWallsPipelines OuterWallsPipeline { get; set; }

        [Required(ErrorMessage = "Вид гідравлічної системи є обов'язковим полем!")]
        [SpecificValues<string>(new string[] { HidraulicSystemTypes.TwoPiped.Value, HidraulicSystemTypes.OnePipedConstantMode.Value, HidraulicSystemTypes.OnePipedVariabletMode.Value })]
        public string HidraulicSystemType { get; set; }

        [Required(ErrorMessage = "Опис гідравлічної системи є обов'язковим полем!")]
        [SpecificValuesFromConstants(new string[] { "EnergyEfficiencyBE.Constants+HidraulicSystemTypes+TwoPiped", "EnergyEfficiencyBE.Constants+HidraulicSystemTypes+OnePipedConstantMode", "EnergyEfficiencyBE.Constants+HidraulicSystemTypes+OnePipedVariabletMode" })]
        public string HidraulicSystemDescription { get; set; }

        [Required(ErrorMessage = "Періодичність опалення є обов'язковим полем!")]
        [SpecificValues<string>(new string[] { PeriodicHeatingModes.Constant, PeriodicHeatingModes.PeriodicWithoutIntegratedFeedback, PeriodicHeatingModes.PeriodicWithIntegratedFeedback })]
        public string PeriodicHeatingType { get; set; }

        [Required(ErrorMessage = "Вид температурного фактору впливу є обов'язковим полем!")]
        public TemperatureComponents TemperatureComponentType { get; set; }

        public TemperatureRegulationOptions RegulationOptions { get; set; }
        public TemperatureDifferenceOptions TemperaturDifference { get; set; }
        public OuterEnclosureHeatLoss HeatLoss { get; set; }

        [Required(ErrorMessage = "Тип сезонного пристрою опалення є обов'язковим полем!")]
        public SeasonalHeatGenerationDevices SeasonalHeaterType { get; set; }

        public bool IsRadiantHeatingSystem { get; set; }

        [NonZero("Поверховість")]
        public int Stories { get; set; }

        [NonZero("Довжина трубопроводу опалення")]
        public float PipelineLength { get; set; }

        [Range(0, 1)]
        [NonZero("Ефективність генерації електроенергії")]
        public float electicityGenerationEfficiency {  get; set; }

        [Range(0, 1)]
        [NonZero("Ефективність генерації теплоти")]
        public float heatGenerationEfficiency { get; set; }

        [NonZero("Загальна внутрішня площа")]
        public decimal TotalInnerArea { get; set; }

        [NonZero("Загальна опалювана площа")]
        public decimal TotalHeatedArea { get; set; }

        [NonZero("Загальна внутрішня висота")]
        public decimal TotalInnerHeight { get; set; }

        [NonZero("Коефіцієнт використання теплоти")]
        public decimal HeatingUsageFactor { get; set; }

        [NonZero("Річна енергія виходу із системи опалення")]
        public decimal YearlyHeatingSubsystemExitEnergy { get; set; }

        [ArrayLength(12, "Середньорічна температура теплоносія")]
        public float[] AvgYearlyHeatCarrierTemp { get; set; }

        [ArrayLength(12, "Середньорічна температура навколишнього середовища")]
        public float[] AvgYearlyEnvironmentTemp { get; set; }

        [ArrayLength(12, "Середньорічна кількість годин опалення на день")]
        public float[] AvgYearlyHeatingHours { get; set; }

        public decimal Price { get; set; }

        public decimal[] heatingConsumptionMonths { get; set; }
    }
}
