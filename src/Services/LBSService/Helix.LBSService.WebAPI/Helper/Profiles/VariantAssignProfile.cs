using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
    public class VariantAssignProfile : Profile
    {
        public VariantAssignProfile()
        {
            CreateMap<VariantAssignDto, LG_VRNTASSIGN>()
                .ForMember(dest => dest.CHARCODE, opt => opt.MapFrom(src => src.VariantPropertyCode))
                .ForMember(dest => dest.CHARDEF, opt => opt.MapFrom(src => src.VariantPropertyName))
                .ForMember(dest => dest.CHARVAL, opt => opt.MapFrom(src => src.VariantPropertyValueCode));
        }
    }
}
