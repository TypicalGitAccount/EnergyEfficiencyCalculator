using AutoMapper;
using EnergyEfficiencyBE.Models.Dtos;
using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Models.Entities.EfficiencyAdvices;

namespace EnergyEfficiencyBE.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EnergyEfficiencyInputModel, HeatingEnergyConsumptionModel>()
                .ForMember(dest => dest.HeatedAreaOrVolume, opt => opt.MapFrom(src => src.TotalHeatedArea));
            CreateMap<EnergyEfficiencyInputModel, PublicBuildingHeatingEnergyConsumptionModel>()
                .ForMember(dest => dest.HeatedAreaOrVolume, opt => opt.MapFrom(src => src.TotalHeatedArea * src.TotalInnerHeight));

            CreateMap<EnergyEfficiencyInputModel, CoolingEnergyConsumptionModel>()
                .ForMember(dest => dest.ConditionedAreaOrVolume, opt => opt.MapFrom(src => src.TotalHeatedArea));
            CreateMap<EnergyEfficiencyInputModel, PublicBuildingCoolingEnergyConsumptionModel>()
                .ForMember(dest => dest.ConditionedAreaOrVolume, opt => opt.MapFrom(src => src.TotalHeatedArea * src.TotalInnerHeight));

            CreateMap<AdviceDto, Advice>();
        }
    }
}
