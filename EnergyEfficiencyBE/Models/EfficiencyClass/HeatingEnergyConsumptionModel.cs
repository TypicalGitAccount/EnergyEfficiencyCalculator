using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.EfficiencyClass
{
    public class HeatingEnergyConsumptionModel
    {
        public decimal HeatedAreaOrVolume { get; set; }
        public PipelineTypes PipelineType { get; set; }
        public PipelineSections[] PipelineSections { get; set; }
        public InsulatedOpenPipelines InsulatedDate { get; set; }
        public OuterWallsPipelines OuterWallsPipeline { get; set; }
        public float PipelineLength { get; set; }
        public float[] AvgYearlyHeatCarrierTemp { get; set; }
        public float[] AvgYearlyEnvironmentTemp { get; set; }
        public float[] AvgYearlyHeatingHours { get; set; }
        public decimal HeatingUsageFactor { get; set; }
        public decimal YearlyHeatingSubsystemExitEnergy { get; set; }
        public string HidraulicSystemType { get; set; }
        public string HidraulicSystemDescription { get; set; }
        public string PeriodicHeatingType { get; set; }
        public bool IsRadiantHeatingSystem { get; set; }
        public TemperatureComponents TemperatureComponentType { get; set; }
        public TemperatureRegulationOptions RegulationOptions { get; set; }
        public TemperatureDifferenceOptions TemperaturDifference { get; set; }
        public OuterEnclosureHeatLoss HeatLoss { get; set; }
        public SeasonalHeatGenerationDevices SeasonalHeaterType { get; set; }
        public HeaterFactors HeaterFactorFieldName { get; set; }
    }
}
