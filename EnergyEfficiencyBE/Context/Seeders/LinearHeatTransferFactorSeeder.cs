using EnergyEfficiencyBE.Models.Entities.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Context.Seeders
{
    public class LinearHeatTransferFactorSeeder
    {
        public static async Task SeedTableAsync(ILinearHeatTransferFactorRepository repository)
        {
            if (repository.FindAllAsync().Result?.Count() < 21)
            {
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.After2014,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 0.2f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.After2014,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 0.3f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.After2014,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 0.4f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.From1980To1995,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 0.3f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.From1980To1995,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 0.4f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.From1980To1995,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 0.4f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.Before1980,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 0.4f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.Before1980,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 0.4f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.InsulatedOpen,
                    InsulatedDate = InsulatedOpenPipelines.Before1980,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 0.4f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaLessThan200,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 1f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaLessThan200,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 1f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaLessThan200,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 1f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFro200To500,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 2f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFro200To500,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 2f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFro200To500,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 2f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFrom500,
                    PipelineSection = PipelineSections.Lv,
                    FactorValue = 3f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFrom500,
                    PipelineSection = PipelineSections.Ls,
                    FactorValue = 3f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.UnIinsulated,
                    BuildingSize = BuildingAreaConstraints.AreaFrom500,
                    PipelineSection = PipelineSections.La,
                    FactorValue = 3f
                });

                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.OuterWalls,
                    OuterWallsPipeline = OuterWallsPipelines.WallsNotInsulated,
                    FactorValue = 1.35f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.OuterWalls,
                    OuterWallsPipeline = OuterWallsPipelines.WallsWithOuterInsulation,
                    FactorValue = 1f
                });
                await repository.CreateAsync(new LinearHeatTransferFactor()
                {
                    PipelineType = PipelineTypes.OuterWalls,
                    OuterWallsPipeline = OuterWallsPipelines.WallsNotInsulatedWithHeatTransferResistance,
                    FactorValue = 0.75f
                });
            }
        }
    }
}
