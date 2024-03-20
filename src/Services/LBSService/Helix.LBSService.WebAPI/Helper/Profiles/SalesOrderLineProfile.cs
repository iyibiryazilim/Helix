using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class SalesOrderLineProfile : Profile
	{
		public SalesOrderLineProfile()
		{
			CreateMap<SalesOrderLineDto, LG_SalesOrderLine>()
			.ForMember(d => d.DUE_DATE, o => o.MapFrom(s => s.OrderDate))
			.ForMember(d => d.VARIANTCODE, o => o.MapFrom(s => s.VariantCode))
			.ForMember(d => d.QUANTITY, o => o.MapFrom(s => s.Quantity))
			.ForMember(d => d.PRICE, o => o.MapFrom(s => s.UnitPrice))
			.ForMember(d => d.TRANS_DESCRIPTION, o => o.MapFrom(s => s.Description))
			.ForMember(d => d.VAT_RATE, o => o.MapFrom(s => s.VatRate))
			.ForMember(d => d.UNIT_CODE, o => o.MapFrom(s => s.UnitsetCode))
			.ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
			.ForMember(d => d.MASTER_CODE, o => o.MapFrom(s => s.ProductCode))
			.ForMember(d => d.TOTAL, o => o.MapFrom(s => s.Total))
			.ForMember(d => d.VAT_AMOUNT, o => o.MapFrom(s => s.TotalVat))
			.ForMember(d => d.TOTAL_NET, o => o.MapFrom(s => s.NetTotal))
			.ForMember(d => d.EDT_CURR, o => o.MapFrom(s => s.EdtCurr))
			.ForMember(d => d.EDT_PRICE, o => o.MapFrom(s => s.EdtPrice));
		}
	}
}