using AutoMapper;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class ConsumableTransactionLineProfile : Profile
	{
		public ConsumableTransactionLineProfile()
		{
			CreateMap<ConsumableTransactionLineDto, LG_ConsumableTransactionLine>()
			  .ForMember(d => d.ITEM_CODE, o => o.MapFrom(s => s.ProductCode))
			  .ForMember(d => d.DESCRIPTION, o => o.MapFrom(s => s.Description))
			  .ForMember(d => d.QUANTITY, o => o.MapFrom(s => s.Quantity))
			  .ForMember(d => d.UNIT_CODE, o => o.MapFrom(s => s.SubUnitsetCode))
			  .ForMember(d => d.SOURCEINDEX, o => o.MapFrom(s => s.WarehouseNumber));
		}
	}
}
