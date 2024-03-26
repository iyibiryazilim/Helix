using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class DemandLineProfile : Profile
	{
		public DemandLineProfile()
		{
			CreateMap<LG_DemandLine, DemandLineDto>()
 				.ForMember(d => d.ProductCode, o => o.MapFrom(s => s.ITEM_CODE))
				.ForMember(d => d.Quantity, o => o.MapFrom(s => s.AMOUNT))
				.ForMember(d => d.Unitset, o => o.MapFrom(s => s.UNIT_CODE))
				.ForMember(d => d.Price, o => o.MapFrom(s => s.PRICE))
				.ForMember(d => d.VariantCode, o => o.MapFrom(s => s.VARIANTCODE))
 				.ReverseMap();
		}
	}
}