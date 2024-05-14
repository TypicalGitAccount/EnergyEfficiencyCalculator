using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Models.Entities.EfficiencyClass
{
    public class LinearHeatTransferFactor : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PipelineTypes PipelineType { get; set; }
        public PipelineSections PipelineSection { get; set; } = PipelineSections.None;
        public InsulatedOpenPipelines InsulatedDate { get; set; } = InsulatedOpenPipelines.None;
        public OuterWallsPipelines OuterWallsPipeline { get; set; } = OuterWallsPipelines.None;
        public BuildingAreaConstraints BuildingSize {  get; set; } = BuildingAreaConstraints.None;
        public float FactorValue { get; set; }
    }
}
