using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class VariantProfile : Profile
	{
		public VariantProfile()
		{
			CreateMap<VariantDto, LG_Variant>()
				.ForMember(dest => dest.CARDTYPE, opt => opt.MapFrom(src => src.CardType))
				.ForMember(dest => dest.UNITSETCODE, opt => opt.MapFrom(src => src.UnitsetCode))
				.ForMember(dest => dest.ICODE, opt => opt.MapFrom(src => src.ProductCode))
				.ForMember(dest => dest.CODE, opt => opt.MapFrom(src => src.Code))
				.ForMember(dest => dest.NAME, opt => opt.MapFrom(src => src.Name));
		}
	}
}