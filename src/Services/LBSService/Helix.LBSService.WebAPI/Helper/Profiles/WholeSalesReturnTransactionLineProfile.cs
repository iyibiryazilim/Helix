using AutoMapper;
using Helix.LBSService.Go.Models;
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

			CreateMap<WholeSalesReturnTransactionLineDto, LG_STLINE>()
.ForMember(d => d.STOCKREF, o => o.MapFrom(s => s.ProductReferenceId))
.ForMember(d => d.TRCODE, o => o.MapFrom(s => s.TransactionType))
.ForMember(d => d.DATE_, o => o.MapFrom(s => s.TransactionDate))
.ForMember(d => d.IOCODE, o => o.MapFrom(s => s.IOType))
.ForMember(d => d.AMOUNT, o => o.MapFrom(s => s.Quantity))
.ForMember(d => d.UINFO1, o => o.MapFrom(s => s.ConversionFactor))
.ForMember(d => d.UINFO2, o => o.MapFrom(s => s.OtherConversionFactor))
.ForMember(d => d.SPECODE, o => o.MapFrom(s => s.SpeCode))
.ForMember(d => d.LINEEXP, o => o.MapFrom(s => s.Description))
.ForMember(d => d.USREF, o => o.MapFrom(s => s.UnitsetReferenceId))
.ForMember(d => d.UOMREF, o => o.MapFrom(s => s.SubUnitsetReferenceId))
.ForMember(d => d.SOURCEINDEX, o => o.MapFrom(s => s.WarehouseNumber));
		}
    }
}
