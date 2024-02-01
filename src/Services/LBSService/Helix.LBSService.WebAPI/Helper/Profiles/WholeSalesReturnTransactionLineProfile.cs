using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class WholeSalesReturnTransactionLineProfile : Profile
	{
        public WholeSalesReturnTransactionLineProfile()
        {
			CreateMap<WholeSalesReturnTransactionLineDto, LG_WholeSalesReturnDispatchLine>()
	 .ForMember(d => d.MASTER_CODE, o => o.MapFrom(s => s.ProductCode))
	 .ForMember(d => d.QUANTITY, o => o.MapFrom(s => s.Quantity))
	 .ForMember(d => d.VAT_RATE, o => o.MapFrom(s => s.VatRate))
	 .ForMember(d => d.PRICE, o => o.MapFrom(s => s.UnitPrice))
	 .ForMember(d => d.ORDER_REFERENCE, o => o.MapFrom(s => s.OrderReferenceId))
	 .ForMember(d => d.UNIT_CODE, o => o.MapFrom(s => s.SubUnitsetCode))
	 .ForMember(d => d.SOURCEINDEX, o => o.MapFrom(s => s.WarehouseNumber));
		}
    }
}
